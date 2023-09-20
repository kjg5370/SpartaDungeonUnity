using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultStatData", menuName = "SpartaDungeonUnity/Stats/Default", order = 0)]
public class StatSO : ScriptableObject
{
    [Header("Stat Info")]
    public float Atk;
    public float Def;
    public float Health;
    public float Critical;
}
