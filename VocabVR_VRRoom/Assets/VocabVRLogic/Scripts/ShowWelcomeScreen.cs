using UnityEngine;

public class ShowWelcomeScreen : MonoBehaviour
{
    // Public fields to reference the UI elements in the Unity Inspector
    public GameObject card1;     
    public GameObject card2;        
    public GameObject card3;        
    public GameObject card4;       
    public GameObject card5;       
    public GameObject card6;
    public GameObject card7;

    public GameObject exclamationMark;

    // Called when the script instance is being loaded
    void Start()
    {
        // Initially display the exclamation mark and hide all cards
        exclamationMark.SetActive(true); // Show the exclamation mark
        card1.SetActive(false);          
        card2.SetActive(false);        
        card3.SetActive(false);          
        card4.SetActive(false);         
        card5.SetActive(false);          
        card6.SetActive(false);    
        card7.SetActive(false);
    }

    // Called when the user interacts with the object (e.g., clicks on it)
    public void ClickOnObject()
    {
        // Hide the exclamation mark and show the first card
        exclamationMark.SetActive(false); 
        card1.SetActive(true);           
    }
}
