using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingLot : MonoBehaviour
{
    public static ParkingLot instance;
    public GameObject carPrefab;

    private void Awake()
    {
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
    public ParkingSpace[] bank1Left;
    public ParkingSpace[] bank1Right;
    public ParkingSpace[] bank2Left;
    public ParkingSpace[] bank2Right;
    public ParkingSpace[] bank3Left;
    public ParkingSpace[] bank3Right;

    public List<GameObject> carsInLot;

    public void CreateCar()
    {
        Car car = Instantiate(carPrefab, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].position, Quaternion.identity).GetComponent<Car>();
    }
}
