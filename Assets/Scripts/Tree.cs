using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private bool _isOccupied;
    
    public bool IsOccupied
    {
        get { return _isOccupied; }
        set { _isOccupied = value; }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isOccupied = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isOccupied = false;
        }
    }
}

