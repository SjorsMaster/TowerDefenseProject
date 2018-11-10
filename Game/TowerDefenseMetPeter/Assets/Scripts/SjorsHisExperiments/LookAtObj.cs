using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObj : MonoBehaviour {
    [SerializeField]
    Transform Target;
	void Update () {
        transform.LookAt(Target);
	}
}
