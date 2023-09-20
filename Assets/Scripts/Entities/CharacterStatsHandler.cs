using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStats { get; private set; }

    public event Action OnLevelUP;

    public List<CharacterStats> statsModifiers = new List<CharacterStats>();


    private void Awake()
    {
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
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.characterName = baseStats.characterName;
        CurrentStats.level = baseStats.level;
        CurrentStats.exp = baseStats.exp;
        CurrentStats.gold = baseStats.gold;

        while (true)
        {
            if(CurrentStats.exp < CurrentStats.level +2)
            {
                break;
            }
            CurrentStats.exp -= CurrentStats.level + 2;
            CurrentStats.level++;
            OnLevelUP?.Invoke();
        }
        
    }
}
