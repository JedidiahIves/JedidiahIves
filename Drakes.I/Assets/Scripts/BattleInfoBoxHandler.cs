using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class BattleInfoBoxHandler : MonoBehaviour
{
    public bool isNPC = true;
    public int NPCIndex = 0;
    public DrakeInfo drake;
    public float health = 1;
    public GameObject[] moveButtons = new GameObject[4];

    public void assignMoves(int n, int mCount, int mAvailable) {
        if (n < mAvailable) {
            if (n < mCount) {
                moveButtons[n].GetComponent<MoveButtonHandler>().PopulateMove(drake.movesIndex[n]);
            } else {
                moveButtons[n].SetActive(false);
            }
            n++;
            assignMoves(n, mCount, mAvailable);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PartyInfo loadedData = null;
        if (isNPC) {
            NPCInfo npcData = DataSaver.loadData<NPCInfo>("npc");
            if (npcData == null) {
                return;
            }
            loadedData = npcData.npcParties[NPCIndex];
        } else {
            loadedData = DataSaver.loadData<PartyInfo>("party");
        }
        if (loadedData == null) {
            return;
        }

        //Display loaded Data
        drake = loadedData.drakes[0];
        Debug.Log("Name: " + drake.name);
        gameObject.transform.Find("Drake.Info").GetComponent<Text>().text = drake.name;
        health = (float)(drake.life) / (float)(drake.stats[0]);
        gameObject.transform.Find("Drake.Health").GetComponent<Slider>().value = health;
        Debug.Log(drake.life + " " + drake.stats[0] + " " + health);
        assignMoves(0, drake.movesIndex.Count, moveButtons.Length);
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
        //if(health != (float)(drake.life) / (float)(drake.stats[0])) { health = (float)(drake.life) / (float)(drake.stats[0]); Debug.Log("health value updated " + drake.name); }
    }
}
