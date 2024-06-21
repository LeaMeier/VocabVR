using UnityEngine;

public class ShowWelcomeScreen : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject exclamationMark;

    void Start()
    {
        exclamationMark.SetActive(true);
        card1.SetActive(false);
        card2.SetActive(false);
        card3.SetActive(false);
    }

    public void ClickOnObject()
    {
        exclamationMark.SetActive(false);
        card1.SetActive(true);
    }
}
