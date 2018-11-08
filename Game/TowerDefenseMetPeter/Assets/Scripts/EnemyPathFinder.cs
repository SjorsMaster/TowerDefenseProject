///////////////////////////////////////
///THIS SCRIPT IS WORK IN PROGRESS!////
///////////////////////////////////////

//////////////////////////////////////////////////////////
////The name should be obvious, it's for the waypoints////
//////////////////////////////////////////////////////////
////This script works with a list, which will look for////
////the transform positions from this list. It moves  ////
////thowards them and then counts up so it knows wher-////
////e to go next! Once it finishes, it loops(Optional)////
////And that's it really, might re-work this all :)   ////
////Something nice and simple for now - Sjors K.      ////
//////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinder : MonoBehaviour {
    [SerializeField]
    List<Transform> PathList;
    int i = 0;
    [SerializeField]
    GameObject SpawnPosition;

    private void Start()
    {
        SpawnPosition = GameObject.Find("SpawnPosition");
        transform.position = SpawnPosition.transform.position;
    }

    private void Update()
    {
        if (i < PathList.Count)
        {
            try
            {
                transform.position = Vector3.MoveTowards(transform.position, PathList[i].position, .1f);
                transform.LookAt(PathList[i]);
                if (transform.position == PathList[i].position)
                {
                    i++;
                }
            }
            catch
            {
                PathList.Remove(PathList[i]);
                Debug.Log("Err: Missing waypoint!\n" +
                          ">Waypoint removed.");
            }
            if(PathList.Count <= 1)
            {
                Debug.Log("Err: PathList has to be greater than 1!\n" +
                          ">Initiating self destruct.");
                Destroy(this.gameObject);

            }
        }
        else
        {
            Debug.Log("Note: End reached!\n");
            Destroy(gameObject);
            //i = 0;
            //Debug.Log("Warn: We're on looping mode!\n" +
            //          ">Re-counting the path now.");
        }
    }
}
