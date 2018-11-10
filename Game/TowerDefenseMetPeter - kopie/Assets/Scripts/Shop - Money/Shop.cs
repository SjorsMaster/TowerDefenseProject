///////////////////////////////////////
///THIS SCRIPT IS WORK IN PROGRESS!////
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{    
	public void Buy(int Price, string Payment) {
        GameObject.Find("GameManager").GetComponent<Currency>().Pay(Price, Payment);
	}


	
}
