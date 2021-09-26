using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    public float cameraSpeed = 0.25f;

    private void Update()
    {
        // when , is pressed, rotate CameraAnchor clockwise at cameraSpeed
        if (Input.GetKey(KeyCode.Comma))
        {
            transform.Rotate(Vector3.up, cameraSpeed);

        }

        // when . is pressed, rotate CameraAnchor counterclockwise at cameraSpeed
        if (Input.GetKey(KeyCode.Period))
        {
            transform.Rotate(Vector3.up, -cameraSpeed);
        }
    }
}
