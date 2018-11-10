using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookThroughMousePos : MonoBehaviour {

    public GameObject test;
    public float distance = 50f;
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {
            Debug.DrawLine(ray.origin, hit.point);
            test.transform.LookAt(hit.point);
        }
    }
}
