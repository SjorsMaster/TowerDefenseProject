using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouseClick : MonoBehaviour {

	public GameObject test;
    public float distance = 50f;
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
				test.transform.position = hit.point;
            }
        }
    }
}
