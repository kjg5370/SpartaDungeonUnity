using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlots;
    public ItemData[] datas;
    // Start is called before the first frame update

    public GameObject EquipUI;

    public static Inventory instance;
    void Awake()
    {
        instance = this;
    }
        void Start()
    {
        int count = datas.Length;
        for(int i = count; i < uiSlots.Length; i++)
        {
            datas[i] = new ItemData();
        }
        UpdateUI();
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
}
