using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]
    int NextRound = 5;
	public void Go () {
        StartCoroutine(Start());
    }

    IEnumerator Start()
    {
        for (int i = 0; i <= NextRound; i++)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(Resources.Load("Enemy"));
        }
        NextRound += 2;
    }
}
