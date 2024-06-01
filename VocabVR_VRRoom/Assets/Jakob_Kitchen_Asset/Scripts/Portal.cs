using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Scene scene;

        // Definiere die Namen der Szenen
        public string sceneToLoad;

        // Wird aufgerufen, wenn ein anderer Collider in den Trigger eintritt
        private void OnTriggerEnter(Collider other)
        {
            // ?berpr?fe, ob das Objekt, das den Trigger ausl?st, der Spieler ist (Annahme: der Spieler hat das Tag "Player")
            if (other.CompareTag("Player"))
            {
                // Szene wechseln
                SceneManager.LoadScene(sceneToLoad);
            }
        }
}
