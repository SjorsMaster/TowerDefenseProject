///////////////////////////////////////
///THIS SCRIPT IS WORK IN PROGRESS!////
///////////////////////////////////////

////////////////////////////////////////////////////
////This script is here to guide the UI elements////
////////////////////////////////////////////////////
////The script will pretty much just change UI  ////
////things being asked to change by other scrip-////
////ts! - Sjors K.                              ////
////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElements : MonoBehaviour {
    
    string GoldUI;
    string ManaUI;

    [SerializeField]
    Text GlobalUI;

    private void Start()
    {
        UpdateValues("Gold", 0);
        UpdateValues("Mana", 1);
    }

    public void UpdateValues (string Type,int Ammount) {
		if(Type == "Gold")
        {
            GoldUI = "<b>❂</b>: " + Ammount;
        }
        else
        {
            ManaUI = "<b>✧</b>: " + Ammount;
        }
        GlobalUI.text = GoldUI + "\n" + ManaUI;
    }
}
