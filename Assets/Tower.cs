using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bullet;

    public float fireRate = 2f;

    public float fireRange = 10f;

    public float bulletSpeed = 10f;

    public float bulletDamage = 1f;

    // make list of enemies in range
    List<Enemy> enemiesInRange = new List<Enemy>();



}
