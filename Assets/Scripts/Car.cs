using System;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float _speed = 10f;
    private float _turnSpeed = 10f;
    private bool _isDriving;
    private Transform _currentTarget;
    private Transform _laneTarget;
    private ParkingSpace _parkingSpace;
    public Transform[] patronStandingPositions;
    public GameObject[] patrons;
    public GameObject patronPrefab;

    private void Awake()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
    }

    public void AddParkingSpace(ParkingSpace parkingSpace)
    {
        _parkingSpace = parkingSpace;
    }

    public void OccupyCar()
    {
        int randomNumber = UnityEngine.Random.Range(0, 4);
        patrons = new GameObject[randomNumber];
        for (int i = 0; i < randomNumber; i++)
        {
            var patron = Instantiate(patronPrefab, patronStandingPositions[i].position, Quaternion.identity);
            patrons[i] = patron;
        }
    }
}
