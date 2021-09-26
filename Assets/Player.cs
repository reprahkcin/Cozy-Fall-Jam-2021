using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Singleton
    public static Player instance;

    private Animator animator;

    public float speed = 4f;

    private Rigidbody rb;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }

    public void MoveToPosition(Vector3 position)
    {
        // move to position at speed
        rb.MovePosition(position * speed * Time.deltaTime);

        // set animation
        //animator.SetFloat("Speed", speed);
    }
}
