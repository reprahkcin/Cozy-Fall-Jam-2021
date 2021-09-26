using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    // Singleton
    public static Squirrel instance;

    public Transform target;



    public float squirrelSpeed = 5f;

    private void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        float step = squirrelSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
