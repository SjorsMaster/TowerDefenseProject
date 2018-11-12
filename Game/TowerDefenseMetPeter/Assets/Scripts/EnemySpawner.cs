using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public void Go () {
        for(int i = 0; i <10; i++)
        {
            StartCoroutine(Wait());
            try
            {
                Instantiate(Resources.Load("Enemy"));
            }
            catch
            {
                Debug.LogWarning("Can't seem to find Enemy!");
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
    }
}
