using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSortClass : MonoBehaviour
{

    public float xOnGrid, yOnGrid;

    public GameObject GridSystem;
    public int[,] GridSystemArray;

    // Use this for initialization
    void Start ()
    {
        GridSystem = GameObject.Find("Grid System");
        GridSystem.GetComponent<GridSystemBasic>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
