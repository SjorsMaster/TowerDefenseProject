using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumBoi : MonoBehaviour {
    private Renderer renderer;
    enum Colors {Red, Green, Blue, Yellow, White};

	void Awake () {
        renderer = GetComponent<Renderer>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyRandomColor();
        }
	}

    void ApplyRandomColor()
    {
        Colors randomColor = (Colors)Random.Range(0, 5);

        switch{
            case Colors.Red: renderer.material.color = Color.red; break;
        }

        if (randomColor == Colors.Red)
            renderer.material.color = Color.red;
        else if (randomColor == Colors.Green)
            renderer.material.color = Color.green;
        else if (randomColor == Colors.Blue)
            renderer.material.color = Color.blue;
        else if (randomColor == Colors.Yellow)
            renderer.material.color = Color.yellow;
        else if (randomColor == Colors.White)
            renderer.material.color = Color.white;
    }
}
