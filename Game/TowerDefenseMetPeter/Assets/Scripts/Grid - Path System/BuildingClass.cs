using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClass : MonoBehaviour 
{
    private GameObject turret;

    private Renderer rend;
    public Color tileStartColor;

    private GameObject gameManager;

    //public TileType tileType;
    public bool buildableTile = false;//The tile script can change this

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        tileStartColor = rend.material.color;

        gameManager = GameObject.Find("GameManager");
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

            if (gameManager.GetComponent<GameManager>().GetGold() >= 100)
            {
                //Build a turret
                turret = Instantiate(Resources.Load("Tower", typeof(GameObject))) as GameObject;//(GameObject)Instantiate(turret, transform.position, transform.rotation);
                turret.transform.position = transform.position;

                //Decrease gold
                gameManager.GetComponent<GameManager>().DecreaseGold(turret.GetComponent<TowerClass>().GetCost());
                gameManager.GetComponent<GameManager>().StopPlacing();
            }
            else
            {
                Debug.Log("Not enough gold");
                gameManager.GetComponent<GameManager>().MainCanvas.GetComponent<MainCanvasManager>().WarningMessage("Not enough gold.");
            }
        }
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
