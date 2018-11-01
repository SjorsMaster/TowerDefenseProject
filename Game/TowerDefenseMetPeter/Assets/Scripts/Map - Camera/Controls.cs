using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class Controls : MonoBehaviour {
    [SerializeField]
    bool PercentageOrPixel;

    [SerializeField]
    float Speed = 1;
    [SerializeField]
    float Percentage = 0.95f;

    void Update () {
        PercentageMovement();
    }

    void PercentageMovement()
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
