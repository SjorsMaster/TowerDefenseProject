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

    private void Start()
    {
        transform.position = new Vector3(0,0,0);
    }

    private void Update()
    {
        if (i < PathList.Count)
        {
            try
            {
                transform.position = Vector3.MoveTowards(transform.position, PathList[i].position, .1f);
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
            i = 0;
            Debug.Log("Warn: We're on looping mode!\n" +
                      ">Re-counting the path now.");
        }
    }
}
