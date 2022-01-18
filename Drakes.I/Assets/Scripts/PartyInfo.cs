using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Moves {
    public int ID;
    public string name;
    public bool isAttack;
    public int attackValue;
    public int accuracyValue;
    public string effectTag;
}

[Serializable]
public class MovesList {
    public List<Moves> moves;
}

[Serializable]
public class DrakeInfo {
    public List<int> ID = new List<int>();
    public List<int> stats = new List<int>() {
        5, //0 - hp
        1, //1 - attack
        1, //2 - defense
        1, //3 - speed
        0, //4 - fire
        0, //5 - water
        0, //6 - lightning
        0, //7 - earth
        0, //8 - leaf
    };
    public string name = "Drake";
    public int life = 5;
    public List<int> movesIndex = new List<int>(4);
    //public float highScore = 0;
}



[Serializable]
public class PartyInfo {
    public List<DrakeInfo> drakes = new List<DrakeInfo>();
    //public float highScore = 0;
}


[Serializable]
public class NPCInfo {
    public List<PartyInfo> npcParties = new List<PartyInfo>() {

    };
}