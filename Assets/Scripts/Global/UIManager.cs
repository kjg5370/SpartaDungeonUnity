using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UIManager : MonoBehaviour
{
    GameManager gameManager;
    private CharacterStatsHandler _statsHandler;

    [SerializeField] private GameObject buttonUI;
    [SerializeField] private GameObject statusUI;

    [SerializeField] private TextMeshProUGUI atkText;
    [SerializeField] private TextMeshProUGUI defText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI criticalText;

    [SerializeField] private GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        _statsHandler = gameManager.Player.GetComponent<CharacterStatsHandler>();
    }

    public void StatusBtn()
    {
        buttonUI.SetActive(false);
        statusUI.SetActive(true);
        atkText.text = _statsHandler.CurrentStats.statSO.Atk.ToString();
        defText.text = _statsHandler.CurrentStats.statSO.Def.ToString();
        healthText.text = _statsHandler.CurrentStats.statSO.Health.ToString();
        criticalText.text = _statsHandler.CurrentStats.statSO.Critical.ToString();
    }

    public void InventoryBtn()
    {
        buttonUI.SetActive(false);
        inventoryUI.SetActive(true);
    }
    public void returnBtn()
    {
        buttonUI.SetActive(true);
        statusUI.SetActive(false);
        inventoryUI.SetActive(false);
    }
}
