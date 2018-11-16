using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddShake : MonoBehaviour
{
    [SerializeField]
    private Vector3 AxesAmount;

    [SerializeField]
    private float time = 0;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(TransformShake(time));
	}

    private IEnumerator TransformShake(float _time)
    {

        transform.position = Vector3.Lerp(transform.position, transform.position + AxesAmount, _time / 2);

        yield return new WaitForSeconds(_time);

        transform.position = Vector3.Lerp(transform.position, transform.position - AxesAmount, _time / 2);

        //StartCoroutine(TransformShake(time));
    }
}
