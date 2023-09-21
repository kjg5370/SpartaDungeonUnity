using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Override,
}

[Serializable]
    public class CharacterStats
    {
        public StatsChangeType statsChangeType;
        public string characterName;
        public int level;
        public int exp;
        public int gold;
        public StatSO statSO;
    }

