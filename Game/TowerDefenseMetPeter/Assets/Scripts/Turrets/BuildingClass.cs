using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClass : MonoBehaviour 
{
    private GameObject turret;

    private Renderer rend;
    public Color tileStartColor;

    //public TileType tileType;
    public bool buildableTile = false;//The tile script can change this

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        tileStartColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (buildableTile)
        {
            if (turret != null)
            {
                Debug.Log("Cant build there - TODO: diplay on screen");
                return;
            }

            //Build a turret
            turret = Instantiate(Resources.Load("Tower", typeof(GameObject))) as GameObject;//(GameObject)Instantiate(turret, transform.position, transform.rotation);
            turret.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update () 
    {


    }

    void OnMouseEnter()
    {
        if (buildableTile)
        rend.material.color = Color.white;
    }

    private void OnMouseExit()
    {
        if (buildableTile)
        rend.material.color = tileStartColor;
    }

}
