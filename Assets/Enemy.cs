using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public float health = 100;

    private Transform target;

    private int wayPointIndex = 0;

    void Start()
    {
        target = WayPoints.points[0];
    }

    void FixedUpdate()
    {
        // If game is not paused
        if (!GameManager.instance.gamePaused)
        {

            // Move rb to the target position
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            // If the distance between the enemy and the target is less than 0.2f, move to the next waypoint
            if (Vector3.Distance(transform.position, target.position) < 0.2f)
            {
                GetNextWayPoint();
            }

            // If health is less than or equal to 0, destroy the enemy
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    void GetNextWayPoint()
    {
        if (wayPointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }

    void EndPath()
    {

        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            // Remove self from GamaManager.instance.enemies
            GameManager.instance.enemies.Remove(this.gameObject);
            EndPath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            TakeDamage(other.GetComponent<Projectile>().damage);
        }
    }


}
