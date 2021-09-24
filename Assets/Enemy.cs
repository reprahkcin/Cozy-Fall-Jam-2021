using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

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




}
