using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{

    [SerializeField]
    private float Health = 100;

    [SerializeField]
    private float Reward = 25;

    private GameObject gameManager;

    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.Find("GameManager");
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckIfDead();
    }

    /// <summary>
    /// Adds health to the object
    /// </summary>
    /// <param name="_amount"></param>
    public void AddHealth(float _amount)
    {
        Health += _amount;

        if (Health > 100)
            Health = 100;
    }

    /// <summary>
    /// Removes health from the object
    /// </summary>
    /// <param name="_amount"></param>
    public void RemoveHealth(float _amount)
    {
        Health -= _amount;

        if (Health < 0)
            Health = 0;
    }

    void CheckIfDead()
    {
        if (Health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        gameManager.GetComponent<GameManager>().IncreaseGold(Reward);

        Destroy(gameObject);

        yield return new WaitForSeconds(1f);
        

    }
}
