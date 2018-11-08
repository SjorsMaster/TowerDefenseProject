using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingOnTile : MonoBehaviour
{
    public bool PlaceActive = true;


    private Transform Pos;
	// Use this for initialization
	void Start ()
    {
        Pos = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (PlaceActive)
        {
            PlaceObject();
        }
	}

    void PlaceObject()
    {
        
    }
}
