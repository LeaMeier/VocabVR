using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayerVR : MonoBehaviour
{
    public Transform playerCamera;

    void Update()
    {
        // Überprüfen, ob die Spieler-Kamera gesetzt ist
        if (playerCamera != null)
        {
            // Berechnen Sie die Richtung von diesem Objekt zur Spieler-Kamera
            Vector3 direction = playerCamera.position - transform.position;

            // Ignorieren Sie die Y-Achse, um ein Kippen zu verhindern
            direction.y = 0;

            // Berechnen Sie die Rotation, die dieses Objekt in Richtung der Kamera zeigt
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            // Setzen Sie die Rotation dieses Objekts
            transform.rotation = rotation;
        }
    }
}
