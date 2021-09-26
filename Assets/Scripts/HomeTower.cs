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


    public Material towerMaterial;

    public Color highlightColor = Color.yellow;

    private Color originalColor = Color.white;

    public void HighlightTower()
    {
        Debug.Log("Highlighted");

        originalColor = towerMaterial.color;
        // Set the color of the towerMaterial to the HighlightColor
        towerMaterial.color = highlightColor;

    }

    public void UnhighlightTower()
    {
        // Set the color of the material to the original color
        towerMaterial.color = originalColor;
    }

    private bool isOccupied = false;

    public void Occupy() => isOccupied = true;

    public void Vacate() => isOccupied = false;
}
