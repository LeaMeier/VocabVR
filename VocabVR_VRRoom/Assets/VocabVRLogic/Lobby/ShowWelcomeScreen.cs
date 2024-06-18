using UnityEngine;

public class ShowWelcomeScreen : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject exclamationMark;

    // Start is called before the first frame update
    void Start()
    {
        exclamationMark.SetActive(true);
        card1.SetActive(false);
        card2.SetActive(false);
        card3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for controller input (e.g., the "A" button on an Xbox controller)
        if (Input.GetButtonDown("Fire1")) // "Fire1" is typically mapped to the "A" button on controllers
        {
            OnControllerClick();
        }
    }

    void OnControllerClick()
    {
        exclamationMark.SetActive(false);
        card1.SetActive(true);
    }
}
