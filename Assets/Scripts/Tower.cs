using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bullet;

    public float fireRate = 10f;

    public float fireRange = 2f;

    public float bulletSpeed = 10f;

    public float bulletDamage = 10f;

    private bool canFire = true;

    private bool isSelected = false; // occupied by squirrel



    public Transform squirrelNest;


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
        if (isSelected && canFire)
        {
            // create bullet as child of tower
            GameObject bulletClone = Instantiate(bullet, squirrelNest.position, Quaternion.identity);
            bulletClone.transform.parent = transform;
            bulletClone.GetComponent<Projectile>().damage = bulletDamage;
            // fire the bullet at the enemy
            bulletClone.GetComponent<Rigidbody>().velocity = (enemy.transform.position - squirrelNest.position).normalized * bulletSpeed;

            canFire = false;
            StartCoroutine(FireCooldown());
        }
    }

    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    public void ActivateTower()
    {
        GameManager.instance.DisableTowers();
        isSelected = true;
    }

    public void DeactivateTower() => isSelected = false;

}
