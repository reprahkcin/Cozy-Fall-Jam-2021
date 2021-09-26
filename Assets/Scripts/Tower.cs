using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bullet;

    public float fireDelayInSeconds = 1f;

    public float fireRange = 3f;

    public float bulletSpeed = 1f;

    public float bulletDamage = 1f;

    [SerializeField]
    private bool isCooledDown = true;

    [SerializeField]
    private bool isOccupied = false;

    // make list of enemies in range
    public List<GameObject> enemiesInRange = new List<GameObject>();




    private void Update()
    {
        enemiesInRange = new List<GameObject>();
        // for each enemy in GameManager.instance.enemies
        foreach (GameObject enemy in GameManager.instance.enemies)
        {
            // if enemy is in range
            if (Vector3.Distance(transform.position, enemy.transform.position) <= fireRange)
            {
                if (enemy != null)
                {
                    // add enemy to list
                    enemiesInRange.Add(enemy);
                }
            }
        }



        // if list is not empty
        if (enemiesInRange.Count > 0)
        {
            // find nearest enemy
            GameObject nearestEnemy = enemiesInRange[0];
            foreach (GameObject enemy in enemiesInRange)
            {
                if (enemy != null)
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) < Vector3.Distance(transform.position, nearestEnemy.transform.position))
                    {
                        nearestEnemy = enemy;
                    }
                }
            }

            // if nearest enemy is not null
            if (nearestEnemy != null)
            {
                Shoot(nearestEnemy);

            }
        }
    }

    void Shoot(GameObject enemy)
    {
        // if is cooled down
        if (isCooledDown && isOccupied)
        {


            // create bullet as child of tower
            GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletClone.transform.parent = transform;
            bulletClone.GetComponent<Projectile>().damage = bulletDamage;
            // fire the bullet at the enemy
            bulletClone.GetComponent<Rigidbody>().velocity = (enemy.transform.position - transform.position).normalized * bulletSpeed;

            isCooledDown = false;
            StartCoroutine(FireCooldown());
        }
    }

    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireDelayInSeconds);
        isCooledDown = true;
    }

    public void Occupy() => isOccupied = true;

    public void Vacate() => isOccupied = false;


}
