using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SpartaDungeonUnity/Stats/Item")]
public class ItemData : StatSO
{
    [Header("Info")]
    public string displayName;
    public string description;
    public Sprite icon;
    public string statName;
    public Sprite statIcon;
}
