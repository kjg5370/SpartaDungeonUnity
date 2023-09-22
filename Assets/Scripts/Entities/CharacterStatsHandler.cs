using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStats { get; private set; }

    public event Action OnUpdateUI;

    public List<CharacterStats> statsModifiers = new List<CharacterStats>();


    private void Awake()
    {
        UpdateCharacterStats();
    }
    public void AddStatModifier(CharacterStats statModifier)
    {
        statsModifiers.Add(statModifier);
        UpdateCharacterStats();
    }
    public void RemoveStatModifier(CharacterStats statModifier)
    {
        statsModifiers.Remove(statModifier);
        UpdateCharacterStats();
    }

    private void UpdateCharacterStats()
    {
        StatSO statSO = null;
        if (baseStats.statSO != null)
        {
            statSO = Instantiate(baseStats.statSO);
        }

        CurrentStats = new CharacterStats { statSO = statSO };
        // TODO
        CurrentStats.characterName = baseStats.characterName;
        UpdateStats((a, b) => b, baseStats);
        foreach (CharacterStats modifier in statsModifiers.OrderBy(o => o.statsChangeType))
        {
            if (modifier.statsChangeType == StatsChangeType.Override)
            {
                UpdateStats((o, o1) => o1, modifier);
            }
            else if (modifier.statsChangeType == StatsChangeType.Add)
            {
                UpdateStats((o, o1) => o + o1, modifier);
            }
            else if (modifier.statsChangeType == StatsChangeType.Sub)
            {
                UpdateStats((o, o1) => o - o1, modifier);
            }
        }

        while (true)
        {
            if(CurrentStats.exp < CurrentStats.level +2)
            {
                break;
            }
            CurrentStats.exp -= CurrentStats.level + 2;
            CurrentStats.level++;
            OnUpdateUI?.Invoke();
        }
        
    }
    private void UpdateStats(Func<float, float, float> operation, CharacterStats newModifier)
    {
        CurrentStats.level = (int)operation(CurrentStats.level, newModifier.level);
        CurrentStats.exp = (int)operation(CurrentStats.exp, newModifier.exp);
        CurrentStats.gold = (int)operation(CurrentStats.gold, newModifier.gold);
        if (CurrentStats.statSO == null || newModifier.statSO == null)
            return;
        UpdateBattleStats(operation, CurrentStats.statSO, newModifier.statSO);
    }
    private void UpdateBattleStats(Func<float, float, float> operation, StatSO currentStat, StatSO newStat)
    {
        if (currentStat == null || newStat == null)
        {
            return;
        }
        currentStat.Atk = operation(currentStat.Atk, newStat.Atk);
        currentStat.Def = operation(currentStat.Def, newStat.Def);
        currentStat.Health = operation(currentStat.Health, newStat.Health);
        currentStat.Critical = operation(currentStat.Critical, newStat.Critical);
    }
}
