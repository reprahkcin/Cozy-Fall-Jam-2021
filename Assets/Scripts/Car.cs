using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;
    public Transform currentTargetPoint;
    public bool isDriving;
    
    public GameObject[] patrons;

    public Transform[] pathIn;
    public Transform[] pathOut;

    private void FixedUpdate()
    {
        if(!isDriving)
            return;

        if (currentTargetPoint == null)
        {
            DriveToPoint(currentTargetPoint);
        }
        
        if (Vector3.Distance(transform.position, currentTargetPoint.position) < 0.1f)
        {
            isDriving = false;
        }
    }
    
    public void DriveToPoint(Transform target)
    {
        currentTargetPoint = target;
        transform.position = Vector3.MoveTowards(transform.position, currentTargetPoint.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, currentTargetPoint.rotation, turnSpeed * Time.deltaTime);
    }

    public void StartDriving()
    {
        isDriving = true;
    }
}
