using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // target to shoot at
    public Transform target;

    // damage of the projectile (assigned at birth)
    public float damage;

    // Get the damage of the projectile
    public float GetDamage()
    {
        return damage;
    }

    public float lifetime = 0.3f;

    private void Start()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
