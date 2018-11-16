using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretClass : MonoBehaviour
{
    #region Enemies
    [Header("Target Variables")]

    [SerializeField]
    //private GameObject Target;
    public float Range = 20f;

    [SerializeField]
    private Transform Target;
    public float rotationSpeed = 10f;
    public string enemyTag = "Enemy";

    #endregion

    #region Fireing
    [Header("Shoot Variables")]

    public bool fire;

    [SerializeField]
    private float Damage = 25;

    [SerializeField]
    private float fireRate = 1.0f;

    //Projectile
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform muzzleTransform;
    #endregion


    // Use this for initialization
    void Start ()
    {
        //Load the bullet from Resources
        projectilePrefab = Resources.Load<GameObject>("Projectile Bullet");
        //Repeat the function twice a seccond
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Target == null)// if there is no target. do nothing
        {
            return;
        }
        else//If there is a target. Shoot, just try and shoot
        {
            Shoot();
        }

        //Rotate to the target
        UpdateRotationToTarget();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject Enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, Enemy.transform.position);

            if (distanceToEnemy < shortestDistance)//Look if the enemy is closer
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = Enemy;
            }

            if (nearestEnemy != null && shortestDistance <= Range)
            {
                Target = nearestEnemy.transform;
            }
            else
            {
                Target = null;
            }

        }
    }

    void UpdateRotationToTarget()
    {
        //Rotate the Turret to the enemy
        Vector3 dir = Target.position - transform.position;//Where to point

        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;//Set the rotation to the new rotation over time

        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);//Ik wil dit nog aanpassen zodat het de snelheid en de afspand van de enemy mee neemt
    }
    

    void Shoot()
    {
        if (fire)//If the turret may fire
        {

            StartCoroutine(FireOnce());
            fire = false;
        }
    }

    IEnumerator FireOnce()
    {
        GameObject projectile = (GameObject)Instantiate(projectilePrefab, muzzleTransform.position, muzzleTransform.rotation);

        ProjectileClass getProjectileClass = projectile.GetComponent<ProjectileClass>();

        if (projectile != null)
        {
            getProjectileClass.Seek(Target);
            getProjectileClass.Damage = Damage;
        }

        //Wait
        yield return new WaitForSeconds(fireRate);

        fire = true;
    }

    /// <summary>
    /// Rotates the turret to an object
    /// </summary>
    /// <param name="_target"></param>
    void RotateTowards(GameObject _target)
    {
        Vector3 targetPosition = new Vector3(_target.transform.position.x, _target.transform.position.y, _target.transform.position.z);

        transform.LookAt(targetPosition);


        Vector3 eulerAngles = transform.rotation.eulerAngles;
        //eulerAngles.x = 0;
        //eulerAngles.z = 0;
        //eulerAngles.y = 0;// eulerAngles.y - 90;

        // Set the altered rotation back
        transform.rotation = Quaternion.Euler(eulerAngles);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
