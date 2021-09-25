using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public static WayPointManager Instance;

    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform SpawnPoint3;

    public GameObject waypointsA;
    public GameObject waypointsB;
    public GameObject waypointsC;
    public GameObject waypointsD;
    public GameObject waypointsE;

    public Transform endPoint;

    public static Transform[] pathA;
    public static Transform[] pathB;
    public static Transform[] pathC;
    public static Transform[] pathD;
    public static Transform[] pathE;

    void Awake()
    {

        Instance = this;

        pathA = new Transform[waypointsA.transform.childCount + 1];
        for (int i = 0; i < pathA.Length; i++)
        {
            pathA[i] = transform.GetChild(i);
        }

        // put the end point at the end of the array
        pathA[pathA.Length - 1] = endPoint;


        pathB = new Transform[waypointsB.transform.childCount + 1];
        for (int i = 0; i < pathB.Length; i++)
        {
            pathB[i] = transform.GetChild(i);
        }

        // put the end point at the end of the array
        pathB[pathB.Length - 1] = endPoint;


        pathC = new Transform[waypointsC.transform.childCount + 1];
        for (int i = 0; i < pathC.Length; i++)
        {
            pathC[i] = transform.GetChild(i);
        }

        // put the end point at the end of the array
        pathC[pathC.Length - 1] = endPoint;

        pathD = new Transform[waypointsD.transform.childCount + 1];
        for (int i = 0; i < pathD.Length; i++)
        {
            pathD[i] = transform.GetChild(i);
        }

        // put the end point at the end of the array
        pathD[pathD.Length - 1] = endPoint;

        pathE = new Transform[waypointsE.transform.childCount + 1];
        for (int i = 0; i < pathE.Length; i++)
        {
            pathE[i] = transform.GetChild(i);
        }

        // put the end point at the end of the array
        pathE[pathE.Length - 1] = endPoint;
    }

}
