using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButtonHandler : MonoBehaviour
{
    public Moves theMove;

    public void PopulateMove(int index) {
        theMove = GameObject.Find("Dont Destroy").GetComponent<DontDestroy>().movesData.moves[index];
        gameObject.GetComponentInChildren<Text>().text = theMove.name;
     }

    public void PerformMove() {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
