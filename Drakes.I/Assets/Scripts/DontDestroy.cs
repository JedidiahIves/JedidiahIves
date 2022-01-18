
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


public class DontDestroy : MonoBehaviour
{
    public MovesList movesData;

    public static string LoadResourceTextfile(string path) {

        string filePath = "Data/" + path.Replace(".json", "");

        TextAsset targetFile = Resources.Load<TextAsset>(filePath);

        return targetFile.text;
    }

    public void DebugListMovesInfo(MovesList list, int n) {
        int m = list.moves.Count;
            if(n < m) {
            Moves move = list.moves[n];
            Debug.Log(move.ID + " " + move.name + " " + move.isAttack + " " + move.attackValue + " " + move.accuracyValue + " " + move.effectTag);
            n++;
            DebugListMovesInfo(list, n);
        }

    }
    // Start is called before the first frame update
    private void Awake() {
        PartyInfo loadedData = DataSaver.loadData<PartyInfo>("party");
        if (loadedData == null) {
            PartyInfo saveData = new PartyInfo();
            DrakeInfo drake = new DrakeInfo();
            drake.name = "Drake " + Random.Range(1, 100);
            saveData.drakes.Add(drake);
            //saveData.highScore = 40;

            //Save data from PlayerInfo to a file named players
            DataSaver.saveData(saveData, "party");
        }
        NPCInfo npcData = DataSaver.loadData<NPCInfo>("npc");
        if (npcData == null) {
            NPCInfo saveData = new NPCInfo();
            PartyInfo party = new PartyInfo();
            DrakeInfo drake = new DrakeInfo();
            drake.name = "Drake " + Random.Range(1, 100);
            party.drakes.Add(drake);
            saveData.npcParties.Add(party);
            //saveData.highScore = 40;

            //Save data from PlayerInfo to a file named players
            DataSaver.saveData(saveData, "npc");
        }

        var jsonTextFile = Resources.Load<TextAsset>("Data/moves");
        movesData = JsonUtility.FromJson<MovesList>(jsonTextFile.text);
        if (movesData == null) {
            Debug.Log("moves data is empty broh");
        } else {
            DebugListMovesInfo(movesData, 0);
        }
        
    }
}
