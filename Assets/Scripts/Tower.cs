using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Material towerMaterial;

    public Color highlightColor = Color.yellow;

    private Color originalColor = Color.white;

    public void HighlightTower()
    {
        Debug.Log("Highlighted");

        originalColor = towerMaterial.color;
        // Set the color of the towerMaterial to the HighlightColor
        towerMaterial.color = highlightColor;

    }

    public void UnhighlightTower()
    {
        // Set the color of the material to the original color
        towerMaterial.color = originalColor;
    }














    public GameObject bullet;

    public float fireDelayInSeconds = 1f;

    public float fireRange = 3f;

    public float bulletSpeed = 1f;

    public float bulletDamage = 1f;

    //public Outline outline;

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
        // if GameManager.instance.nutsToThrow > 0
        if (GameManager.instance.nutsToThrow > 0)
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
                GameManager.instance.RemoveNuts(1);
            }
        }
    }

    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireDelayInSeconds);
        isCooledDown = true;
    }

    public void Occupy() => isOccupied = true;

    public void Vacate() => isOccupied = false;

    //public void EnableOutline() => outline.enabled = true;

    //public void DisableOutline() => outline.enabled = false;

    // Get the child GameObject of the tower
    public GameObject GetChild()
    {
        return transform.GetChild(0).gameObject;
    }


}
