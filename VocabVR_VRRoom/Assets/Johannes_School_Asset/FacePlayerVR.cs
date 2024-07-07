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
            // Berechnen der Richtung von diesem Objekt zur Spieler-Kamera
            Vector3 direction = playerCamera.position - transform.position;

            // Ignorieren der Y-Achse, um ein Kippen zu verhindern
            direction.y = 0;

            // Berechnen der Rotation, die dieses Objekt in Richtung der Kamera zeigt
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            // Setzen der Rotation dieses Objekts
            transform.rotation = rotation;
        }
    }
}
