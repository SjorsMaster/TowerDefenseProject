using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int i = 0;
    Transform GoalPosition;

    private void Start()
    {
        transform.position = new Vector3(GameObject.Find("Tile - Spawnpoint").transform.position.x, 5, GameObject.Find("Tile - Spawnpoint").transform.position.z);
        getGoalPosition();
    }

    void Update () {            
        if (this.transform.position != GoalPosition.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, GoalPosition.position, .5f);
            transform.LookAt(GoalPosition);
        }
        else
        {
            getGoalPosition();
        }
    }

    void getGoalPosition()
    {
        if (i <= 6)
        {
            if (i == 1)
            {
                GoalPosition = GameObject.Find("GameManager").GetComponent<NewPathFinder>().GetNextPos(2);
            }
            else if (i == 2)
            {
                GoalPosition = GameObject.Find("GameManager").GetComponent<NewPathFinder>().GetNextPos(1);
            }
            else
            {
                try
                {
                    GoalPosition = GameObject.Find("GameManager").GetComponent<NewPathFinder>().GetNextPos(i);
                }
                catch
                {
                    Destroy(gameObject);
                }
            }
            i++;
        }
    }
}
