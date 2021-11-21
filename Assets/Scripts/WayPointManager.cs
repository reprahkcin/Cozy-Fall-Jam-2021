using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public static WayPointManager instance;

    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform SpawnPoint3;

    public GameObject waypointsA;
    public GameObject waypointsB;
    public GameObject waypointsC;
    public GameObject waypointsD;
    public GameObject waypointsE;

    public Transform endPoint;

    public List<Transform> pathA;
    public List<Transform> pathB;
    public List<Transform> pathC;
    public List<Transform> pathD;
    public List<Transform> pathE;

    public List<Transform> RandomPath()
    {
        // generate random number for 5 choices
        int random = Random.Range(0, 5);


        switch (random)
        {
            case 0:
                return pathA;

            case 1:
                return pathB;

            case 2:
                return pathC;

            case 3:
                return pathD;

            case 4:
                return pathE;

            default: return pathA;
        }
    }



    void Awake()
    {

        instance = this;

        pathA = new List<Transform>();
        pathB = new List<Transform>();
        pathC = new List<Transform>();
        pathD = new List<Transform>();
        pathE = new List<Transform>();


        // add the spawn point to the list
        pathA.Add(SpawnPoint1);
        foreach (Transform child in waypointsA.transform)
        {
            pathA.Add(child);
        }
        // add the end point to the list
        pathA.Add(endPoint);

        // add the spawn point to the list
        pathB.Add(SpawnPoint1);
        foreach (Transform child in waypointsB.transform)
        {
            pathB.Add(child);
        }
        // add the end point to the list
        pathB.Add(endPoint);

        // add the spawn point to the list
        pathC.Add(SpawnPoint2);
        foreach (Transform child in waypointsC.transform)
        {
            pathC.Add(child);
        }
        // add the end point to the list
        pathC.Add(endPoint);

        // add the spawn point to the list
        pathD.Add(SpawnPoint2);
        foreach (Transform child in waypointsD.transform)
        {
            pathD.Add(child);
        }
        // add the end point to the list
        pathD.Add(endPoint);

        // add the spawn point to the list
        pathE.Add(SpawnPoint3);
        foreach (Transform child in waypointsE.transform)
        {
            pathE.Add(child);
        }
        // add the end point to the list
        pathE.Add(endPoint);


    }

}
