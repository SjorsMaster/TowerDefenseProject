using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPathFinder : MonoBehaviour {
    List<Transform> Waypoints;

	void Awake () {
        for (int i = 0; i < 6; i++)
        {
            if(GameObject.Find("Waypoint" + i +1) != null)
            Waypoints.Add(GameObject.Find("Waypoint" + i).transform);
        }
	}

	public Transform GetNextPos(int Number) {
        return Waypoints[Number];
	}
}
