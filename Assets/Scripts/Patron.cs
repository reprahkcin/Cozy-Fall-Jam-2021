using System;
using UnityEngine;

public class Patron : MonoBehaviour
{
    public float speed;
    public float health;
    
    public bool isMoving;
    public Transform currentTarget;
    
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isMoving)
        {
            return;
        }
        MoveToTarget(currentTarget);
    }

    public void MoveToTarget(Transform _target)
    {
        Vector3 direction = _target.position - transform.position;
        direction.y = 0;
        rb.AddForce(direction.normalized * speed);
    }

    public void Retreat()
    {
        // flip waypoint list back to car
        // turn around
        // move forward
    }
}
