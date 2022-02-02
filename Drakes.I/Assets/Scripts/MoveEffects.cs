using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffects : MonoBehaviour
{
    public bool targetSelf; //
    public int abilityIndex;
    public bool raise;
    private string[] tagRef = {
        "accuracy",
        "defense",
        "attack",
        "speed"
    };

    public int indexSearch(string ability,int i) {
        if (ability != tagRef[i]) i = indexSearch(ability, i+1);
        return i;
    }
    public string[] ParseTag(string wholeTag) {
        string[] tags = wholeTag.Split(".");
        foreach (var tag in tags) { 
            Debug.Log(tag); 
        }
        targetSelf = tags[0] == "self";
        abilityIndex = indexSearch(tags[1], 0);
        raise = tags[2] == "raise";
        return tags;
    }

}
