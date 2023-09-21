using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlots;
    public ItemData[] datas;

    public GameObject EquipUI;

    [Header("Selected Item")]
    private ItemData selectedItem;
    private int selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatNames;
    public TextMeshProUGUI selectedItemStatValues;
    public TextMeshProUGUI queryText;
    public Image selectedItemIcon;
    public Image selectedItemStatIcon;

    private CharacterStats statsModifier = new CharacterStats();
    private CharacterStatsHandler statsHandler;

    public static Inventory instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        int count = datas.Length;
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
        for (int i = count; i < uiSlots.Length; i++)
        {
            datas[i] = new ItemData();
        }
        UpdateUI();
        statsHandler = gameObject.GetComponent<CharacterStatsHandler>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < datas.Length; i++)
        {
            if (datas[i] != null)
                uiSlots[i].Set(datas[i]);
            else
                uiSlots[i].Clear();
        }
    }
    public void SelectItem(int index)
    {
        
        if (datas[index] == null)
            return;

        selectedItem = datas[index];
        selectedItemIndex = index;

        StatSO selectedItemStatSO = selectedItem;

        selectedItemName.text = selectedItem.displayName;
        selectedItemDescription.text = selectedItem.description;
        selectedItemIcon.sprite = selectedItem.icon;

        selectedItemStatNames.text = selectedItem.statName;
        selectedItemStatIcon.sprite = selectedItem.statIcon;

        switch(selectedItem.statName)
        {
            case "Attack":
                selectedItemStatValues.text = selectedItemStatSO.Atk.ToString();
                break;
            case "Defense":
                selectedItemStatValues.text = selectedItemStatSO.Def.ToString();
                break;
            case "Health":
                selectedItemStatValues.text = selectedItemStatSO.Health.ToString();
                break;
            case "Critical":
                selectedItemStatValues.text = selectedItemStatSO.Critical.ToString();
                break;
        }
    }

    public void ConfirmButton()
    {
        if (!uiSlots[selectedItemIndex].equipped)
        {
            statsModifier.statsChangeType = StatsChangeType.Add;
            statsModifier.statSO = datas[selectedItemIndex];
            statsHandler.AddStatModifier(statsModifier);
            uiSlots[selectedItemIndex].equipped = true;
            uiSlots[selectedItemIndex].equipImage.gameObject.SetActive(true); 
        }
        else if(uiSlots[selectedItemIndex].equipped)
        {
            statsHandler.RemoveStatModifier(statsModifier);
            uiSlots[selectedItemIndex].equipped = false;
            uiSlots[selectedItemIndex].equipImage.gameObject.SetActive(false);
        }
        EquipUI.SetActive(false);
       
    }

    public void CancleButton()
    {
        EquipUI.SetActive(false);
    }

}
