using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // target to shoot at
    public Transform target;

    // damage of the projectile (assigned at birth)
    private float damage;

    // Get the damage of the projectile
    public float GetDamage()
    {
        return damage;
    }

    public float lifetime = 0.3f;

    private void Start()
    {
        StartCoroutine(Die());

        // get bulletDamage from parent tower gameobject
        damage = transform.parent.GetComponent<Tower>().bulletDamage;
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
