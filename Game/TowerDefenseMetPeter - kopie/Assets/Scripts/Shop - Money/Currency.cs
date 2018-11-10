///////////////////////////////////////
///THIS SCRIPT IS WORK IN PROGRESS!////
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {
    int Gold;
    int Mana;
    

    public int Pay(int Ammount, string Currency)
    {
        if (Currency == "Gold")
        {
            if (Gold - Ammount > 0)
            {
                Gold -= Ammount;
            }
            else
            {
                Debug.Log("You don't have enough " + Currency + "!");
            }
            return Gold;
        }
        else
        {
            if (Mana - Ammount > 0)
            {
                Mana -= Ammount;
            }
            else
            {
                Debug.Log("You don't have enough " + Currency + "!");
            }
            return Mana;
        }
    }

    public void Give(int Ammount, string Currency)
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
