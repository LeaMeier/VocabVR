using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera2D : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector3 direction = cameraTransform.position - transform.position;
        direction.z = 0.0f;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
