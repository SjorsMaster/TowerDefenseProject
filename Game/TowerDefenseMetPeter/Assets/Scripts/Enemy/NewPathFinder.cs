using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPathFinder : MonoBehaviour {

    [SerializeField]
    List<Transform> Waypoints;

    private void Start()
    {
          checkPoints();
    }

    void checkPoints()
    {
        for (int i = 1; i < 6 + 1; i++)
        {
              Waypoints.Add(GameObject.Find("Waypoint" + i).transform);
        }
    }

    public Transform GetNextPos(int Number) {
        return Waypoints[Number];
	}
}
