///////////////////////////////////////
///THIS SCRIPT IS WORK IN PROGRESS!////
///////////////////////////////////////

////////////////////////////////////////////////////
////This script reads the player input/ presses.////
////////////////////////////////////////////////////
////In here, we're looking for the mouse positi-////
////on, and from that we'll see if its outside  ////
////The safezone (%) of the screen, depending on////
////that we move the position of the screen! It-////
////'s THAT simple! Other than that we look for ////
////other keypresses.. Nothing too special!     ////
//// - Sjors K.                                 ////
////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    ///Might have to work with an ENUM in this!!

    [SerializeField]
    float Speed = 1;
    [SerializeField]
    float Percentage = 0.95f;

    void Update ()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.mousePosition.y <= Screen.height || Input.mousePosition.y >= Screen.height * Percentage && Input.mousePosition.y <= Screen.height)
        {
            MoveThoward("Down");
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.mousePosition.x <= Screen.width || Input.mousePosition.x >= Screen.width * Percentage && Input.mousePosition.x <= Screen.width)
        {
            MoveThoward("Left");
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.mousePosition.y >= 0 || Input.mousePosition.y <= Screen.width * (-Percentage + 1) && Input.mousePosition.y >= 0)
        {
            MoveThoward("Up");
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.mousePosition.x >= 0 || Input.mousePosition.x <= Screen.width * (-Percentage + 1) && Input.mousePosition.x >= 0)
        {
            MoveThoward("Right");
        }
    }

    void MoveThoward(string Direction)
    {
        GameObject.Find("PlayerMover").GetComponent<CameraMovement>().MoveDirection(Direction, Speed);
    }
}
