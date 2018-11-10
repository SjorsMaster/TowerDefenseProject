///////////////////////////////////////
///THIS SCRIPT IS WORK IN PROGRESS!////
///////////////////////////////////////

///////////////////////////////////////////////////////
////As the title says, This script moves the camera////
///////////////////////////////////////////////////////
////Nothing more to say, it executes what it's bei-////
////ng asked. - Sjors K.                           ////
///////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]
    float MaxDistance;


    public void MoveDirection(string Dir, float Speed)
    {
        if(Dir == "Up")
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
        if (Dir == "Down")
        {
            transform.Translate(Vector3.back * Time.deltaTime * Speed);
        }
        if (Dir == "Left")
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        if (Dir == "Right")
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
    }
}
