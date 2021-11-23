using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingPath : MonoBehaviour
{
    // singleton
    public static ParkingPath instance;

    private void Awake()
    {
        // singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Transform[] spawnPoints;
    public Transform[] laneEnds;
    public Transform[] parkingSpaces;
    
}
