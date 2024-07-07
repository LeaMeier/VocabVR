using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{

    public Transform head; //Referenz auf den Kopf des Charakters
    public Transform feet; //Referenz auf die Füße des Charakters
  
    void Start()
    {

    }

    // Update wird jeden Frame ausgeführt
    void Update()
    {
        gameObject.transform.position = new Vector3(head.position.x, feet.position.y, head.position.z); // Setzt die Position des GameObjects basierend auf den Positionen von Kopf und Füßen

    }
}
