using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject Player { get; private set; }
    [SerializeField] private string playerTag = "Player";

    private CharacterStatsHandler _statsHandler;

    [SerializeField] private TextMeshProUGUI jobText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI descriptText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Slider expGaugeSlider;

    private void Awake()
    {
        instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag);
        _statsHandler = Player.GetComponent<CharacterStatsHandler>();
        _statsHandler.OnLevelUP += UpdateExpUI;
    }

    void Start()
    {
        JobStatData jobStatData = _statsHandler.CurrentStats.statSO as JobStatData;
        jobText.text = jobStatData.JobName;
        nameText.text = _statsHandler.CurrentStats.characterName;
        levelText.text = _statsHandler.CurrentStats.level.ToString();
        expText.text = $"{_statsHandler.CurrentStats.exp} / {_statsHandler.CurrentStats.level + 2}";
        descriptText.text = jobStatData.Descript;
        goldText.text = _statsHandler.CurrentStats.gold.ToString();
    }

    private void UpdateExpUI()
    {
        float gauge =_statsHandler.CurrentStats.exp / (float)(_statsHandler.CurrentStats.level + 2);
        expGaugeSlider.value = gauge;
    }
}
