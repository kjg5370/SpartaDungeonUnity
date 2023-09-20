using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JobStatData", menuName = "SpartaDungeonUnity/Stats/Job", order = 1)]
public class JobStatData : StatSO
{
    [Header("Job Stat Data")]
    public string JobName;
    public string Descript;
}
