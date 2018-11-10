using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    void Death(int Price, string Payment)
    {
        GameObject.Find("GameManager").GetComponent<Currency>().Pay(Price, Payment);
        Debug.Log("Have died.");

        Destroy(gameObject);
    }
}
