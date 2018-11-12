using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{

    public float Health = 100;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    /// <summary>
    /// Adds health to the object
    /// </summary>
    /// <param name="_amount"></param>
    void AddHealth(float _amount)
    {
        Health += _amount;
    }

    /// <summary>
    /// Removes health from the object
    /// </summary>
    /// <param name="_amount"></param>
    void RemoveHealth(float _amount)
    {
        Health -= _amount;
    }
}
