///////////////////////////////////////
///THIS SCRIPT IS WORK IN PROGRESS!////
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {
    int Gold;
    int Mana;
    

    void Pay(int Ammount, string Currency)
    {
        if (Currency == "Gold")
        {
            Gold -= Ammount;
        }
        else
        {
            Mana -= Ammount;
        }
    }

    void Give(int Ammount, string Currency)
    {
        if (Currency == "Gold")
        {
            Gold += Ammount;
        }
        else
        {
            Mana += Ammount;
        }
    }

    void UpdateUI()
    {
        
    }
}
