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
        DrakeInfo enemyDrake = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BattleInfoBoxHandler>().drake;
        DrakeInfo playerDrake = gameObject.GetComponentInParent<BattleInfoBoxHandler>().drake;


        /* checks to see if the move hits. subtracts the accuracy from the calculated evasion. if calculated evasion is lower than the accuracy, 
        it always hits, other wise the chance to hit is the difference between the values*/
        if (((((float)enemyDrake.stats[1] + (float)enemyDrake.stats[2]) / 50f) - (float)theMove.accuracyValue) / 10f > Random.value) {
            int damage = Mathf.CeilToInt(Mathf.Pow((float)playerDrake.stats[1], .5f + ((float)theMove.attackValue / 25) + Random.Range(0f, .1f)));
            Debug.Log(enemyDrake.life + " - " + damage);
            enemyDrake.life -= damage;
            GameObject.FindGameObjectWithTag("Enemy").transform.Find("Drake.Health").GetComponent<Slider>().value = (float)enemyDrake.life / (float)enemyDrake.stats[0];
            Debug.Log(enemyDrake.name + " hit with " + theMove.name);
        } else {
            Debug.Log("Missed!");
        }
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
