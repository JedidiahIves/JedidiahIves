using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DrakeInfo {
    public List<int> ID = new List<int>();
    public List<int> Stats = new List<int>();
    public string name = "Drake";
    public int life = 0;
    //public float highScore = 0;
}

[Serializable]
public class PartyInfo {
    public List<DrakeInfo> drakes = new List<DrakeInfo>();
    //public float highScore = 0;
}