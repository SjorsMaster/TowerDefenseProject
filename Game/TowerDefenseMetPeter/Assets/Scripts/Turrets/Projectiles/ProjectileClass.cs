using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileClass : MonoBehaviour 
{
    private Transform Target;

    public float Speed = 70f;

    public void Seek(Transform _target)
    {
        Target = _target;
    }

    // Use this for initialization
    void Start () 
    {
		

    }
	
	
    // Update is called once per frame
    void Update () 
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = Target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject impactEffectIns = (GameObject)Instantiate(Resources.Load("Particles/BulletImpactEffect", typeof(GameObject)),transform.position, transform.rotation);
        Destroy(impactEffectIns, 2f);

        Destroy(gameObject);
    }

}
