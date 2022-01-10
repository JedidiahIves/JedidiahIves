using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BattleInfoBoxHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PartyInfo loadedData = DataSaver.loadData<PartyInfo>("party");
        if (loadedData == null) {
            return;
        }

        //Display loaded Data
        Debug.Log("Name: " + loadedData.drakes[0].name);
        GameObject.Find("Drake.Info").GetComponent<Text>().text = loadedData.drakes[0].name;
        /*Debug.Log("High Score: " + loadedData.highScore);

        for (int i = 0; i < loadedData.ID.Count; i++) {
            Debug.Log("ID: " + loadedData.ID[i]);
        }
        for (int i = 0; i < loadedData.Amounts.Count; i++) {
            Debug.Log("Amounts: " + loadedData.Amounts[i]);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
