using System;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 10f;
    public bool isDriving;
    public Transform currentTarget;
    private Queue<Transform> waypoints;
    public GameObject[] patrons;

    public Transform[] pathIn;
    public Transform[] pathOut;

}
