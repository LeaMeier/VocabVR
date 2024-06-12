using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera2D : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        // Find the camera in the scene (assuming there's only one)
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Calculate direction from sprite to camera
        Vector3 direction = cameraTransform.position - transform.position;

        // We only care about the horizontal direction
        direction.z = 0.0f;

        // Calculate the angle and apply it to the sprite
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
