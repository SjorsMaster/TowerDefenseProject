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
        if (Dir == "Up")
        {
            if(transform.position.x > 10)
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
        if (Dir == "Down")
        {
            if (transform.position.x < 100)
                transform.Translate(Vector3.back * Time.deltaTime * Speed);
        }
        if (Dir == "Left")
        {
            if (transform.position.z > 0)
                transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        if (Dir == "Right")
        {
            if (transform.position.z < 90)
                transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        if (Dir == "Zoom+")
        {
            if (transform.position.y > 10)
                transform.Translate(Vector3.down * Time.deltaTime * Speed);
        }
        if (Dir == "Zoom-")
        {
            if (transform.position.y < 50)
                transform.Translate(Vector3.up * Time.deltaTime * Speed);
        }
    }
}

