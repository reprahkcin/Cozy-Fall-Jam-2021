using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTower : MonoBehaviour
{
    // Singleton
    public static HomeTower instance;

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
}
