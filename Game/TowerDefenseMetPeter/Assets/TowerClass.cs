using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerClass : MonoBehaviour
{

    [SerializeField]
    private float Cost = 100, Health = 100;

    public bool Placing = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Placing)
        {
            //var getMouse = Input.mousePosition;
            Vector3 mousePosition = Input.mousePosition;
            //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.y = 0;

            Debug.Log(mousePosition);
            //Vector3 getMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = mousePosition;
        }
	}

    /// <summary>
    /// Gets the cost of the tower
    /// </summary>
    /// <returns></returns>
    public float GetCost()
    {
        return Cost;
    }

    /// <summary>
    /// Gets the health of the tower;
    /// </summary>
    /// <returns></returns>
    public float GetHealth()
    {
        return Health;
    }

    /// <summary>
    /// Increases the towers health
    /// </summary>
    /// <param name="_amount"></param>
    public void IncreaseHealth(float _amount)
    {
        Health += _amount;

        if (Health > 100)
        Health = 100;
    }

    /// <summary>
    /// Decreases the towers health
    /// </summary>
    /// <param name="_amount"></param>
    public void DecreaseHealth(float _amount)
    {
        Health -= _amount;

        if (Health < 0)
        Health = 0;
    }

    /// <summary>
    /// Enables you to place a tower
    /// </summary>
    public void StartPlaceingTower()
    {
        Placing = true;

        //Renderer[] renderers = GetComponentsInChildren<Renderer>();

        //foreach (var childRenderer in renderers)
        //{
        //    //Turns the whole tower transparent
        //    Color childColor = childRenderer.material.color;
        //    childColor.a = 0.5f;
        //    childRenderer.material.SetColor("_Color", childColor);
        //}
    }

    /// <summary>
    /// Exits the tower placing mode
    /// </summary>
    public void StopPlaceingTower()
    {
        Placing = false;
    }



}
