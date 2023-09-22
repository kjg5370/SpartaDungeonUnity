using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Image icon;
    public Image equipImage;
    // Start is called before the first frame update
    public CharacterStats characterStats;

    public int index;
    public bool equipped;
    public void Set(ItemData data)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = data.icon;
        characterStats = new CharacterStats();
        characterStats.statSO = data;
    }
    public void Clear()
    {
        icon.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (icon.gameObject.activeSelf)
        {
            Inventory.instance.EquipUI.SetActive(true);
            if (equipped)
                Inventory.instance.queryText.text = "장착 해제 하시겠습니까?";
            else
                Inventory.instance.queryText.text = "장착 하시겠습니까?";
            Inventory.instance.SelectItem(index);
        }
    }
}
