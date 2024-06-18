using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public string sceneToLoad;
    public Image fadeImage; // Referenz zum FadeImage

    private void Start()
    {


        // Sicherstellen, dass Lichtquellen nicht zerstört werden
        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light light in lights)
        {
            DontDestroyOnLoad(light.gameObject);
        }


        // Deaktiviere das FadeImage am Anfang
        fadeImage.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeAndSwitchScene());
        }
    }

    private IEnumerator FadeAndSwitchScene()
    {
        // Aktiviere das FadeImage und setze die Alpha auf 0
        fadeImage.gameObject.SetActive(true);
        Color color = fadeImage.color;
        color.a = 0;
        fadeImage.color = color;

        // Fadiere zu Schwarz über 2 Sekunden
        float fadeDuration = 2f;
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Szene wechseln
        SceneManager.LoadScene(sceneToLoad);

        // Warte einen Frame, damit die Szene laden kann
        yield return null;

        // Fadiere zurück zu transparent über 2 Sekunden
        elapsedTime = 0f;
        fadeImage.gameObject.SetActive(true);
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1 - (elapsedTime / fadeDuration));
            fadeImage.color = color;
            yield return null;
        }

        // Deaktiviere das FadeImage
        fadeImage.gameObject.SetActive(false);
    }
}
