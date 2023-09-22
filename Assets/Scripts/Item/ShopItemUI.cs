using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    public Image icon;
    public Image statIcon;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemStatValues;
    public TextMeshProUGUI itemPrice;

    [SerializeField] CharacterStats statsModifier;

    [SerializeField] ItemData data;

    private void Start()
    {
        icon.sprite = data.icon;
        statIcon.sprite = data.statIcon;
        itemName.text = data.displayName;
        itemDescription.text = data.description;
        itemPrice.text = string.Format("{0: #,###}",data.price);

        statsModifier.gold = data.price;

        StatSO statSO = data;
        Color color;
        switch (data.statName)
        {
            case "Attack":
                itemStatValues.text = statSO.Atk.ToString();
                itemStatValues.color = Color.red;
                break;
            case "Defense":
                itemStatValues.text = statSO.Def.ToString();
                itemStatValues.color = Color.blue;
                break;
            case "Health":
                itemStatValues.text = statSO.Health.ToString();
                itemStatValues.color = Color.green;
                break;
            case "Critical":
                itemStatValues.text = statSO.Critical.ToString();
                ColorUtility.TryParseHtmlString("#FFBF00", out color);
                itemStatValues.color = color;
                break;
        }
    }
    public void OnBuyButtonClick()
    {
        Inventory.instance.AddShopItem(data,statsModifier);
    }
}
