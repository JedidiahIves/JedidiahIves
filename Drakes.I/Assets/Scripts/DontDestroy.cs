using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
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
    }
}
