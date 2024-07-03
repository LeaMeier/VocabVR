using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractableObject : MonoBehaviour
{
    // Public fields for referencing UI elements in the Unity Inspector
    public GameObject exclamationMarkRed;     
    public GameObject exclamationMarkOrange;  
    public GameObject exclamationMarkGreen;   
    public GameObject readCard;               
    public GameObject listenCard;             
    public GameObject checkBackCard;          
    public GameObject rightAnswerCard;       
    public GameObject wrongAnswerCard;        
    public Button closeButtonRead;            
    public Button closeButtonListen;          
    public Button closeButtonWrongAnswer;     
    public Button closeButtonRightAnswer;     
    public Button listenButton;              
    public Button rightAnswer;                
    public Button wrongAnswer;                
    public Button wrongAnswer2;               
    public Button wrongAnswer3;              

    // Reference to the player's camera to orient cards towards the player
    public Transform playerCamera;

    // Audio output
    private AudioSource audioSource;           // Component for playing audio
    public AudioClip audioClip;                // Audio clip to be played

    void Start()
    {
        // Initialize the visibility of the UI elements
        exclamationMarkRed.SetActive(true);     
        exclamationMarkOrange.SetActive(false); 
        exclamationMarkGreen.SetActive(false);  
        readCard.SetActive(false);              
        listenCard.SetActive(false);           
        checkBackCard.SetActive(false);         
        rightAnswerCard.SetActive(false);       
        wrongAnswerCard.SetActive(false);       

        // Add listeners to the buttons to handle click events
        closeButtonRead.onClick.AddListener(CloseReadCard);
        closeButtonListen.onClick.AddListener(CloseListenCard);
        listenButton.onClick.AddListener(PlayWord);
        rightAnswer.onClick.AddListener(AnsweredRight);
        wrongAnswer.onClick.AddListener(AnsweredWrong);
        wrongAnswer2.onClick.AddListener(AnsweredWrong);
        wrongAnswer3.onClick.AddListener(AnsweredWrong);
        closeButtonWrongAnswer.onClick.AddListener(CloseWrongAnswerCard);
        closeButtonRightAnswer.onClick.AddListener(CloseRightAnswerCard);

        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Method called when the object is clicked
    public void ClickOnObject()
    {
        // Check which exclamation mark is active and display the corresponding card
        if (exclamationMarkRed.activeSelf)
        {
            exclamationMarkRed.SetActive(false);        // Hide the red exclamation mark
            readCard.SetActive(true);                   // Show the read card
            OrientCardTowardsPlayer(readCard);          // Orient the card towards the player
        }

        if (exclamationMarkOrange.activeSelf)
        {
            exclamationMarkOrange.SetActive(false);     // Hide the orange exclamation mark
            listenCard.SetActive(true);                 // Show the listen card
            OrientCardTowardsPlayer(listenCard);        // Orient the card towards the player
        }

        if (exclamationMarkGreen.activeSelf)
        {
            exclamationMarkGreen.SetActive(false);      // Hide the green exclamation mark
            checkBackCard.SetActive(true);              // Show the check back card
            OrientCardTowardsPlayer(checkBackCard);     // Orient the card towards the player
        }
    }

    // Method to close the read card and show the orange exclamation mark
    void CloseReadCard()
    {
        readCard.SetActive(false);              
        exclamationMarkOrange.SetActive(true);  
    }

    // Method to close the listen card and show the green exclamation mark
    void CloseListenCard()
    {
        listenCard.SetActive(false);             
        exclamationMarkGreen.SetActive(true);   
    }

    // Method to play the audio clip
    void PlayWord()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();                  // Stop any currently playing audio
        }
        audioSource.clip = audioClip;            // Set the audio clip to play
        audioSource.Play();                      // Play the audio clip
    }

    // Method to show the right answer card and hide the check back card
    void AnsweredRight()
    {
        checkBackCard.SetActive(false);         
        rightAnswerCard.SetActive(true);        
        OrientCardTowardsPlayer(rightAnswerCard); 
    }

    // Method to show the wrong answer card and hide the check back card
    void AnsweredWrong()
    {
        checkBackCard.SetActive(false);         
        wrongAnswerCard.SetActive(true);        
        OrientCardTowardsPlayer(wrongAnswerCard); 
    }

    // Method to close the right answer card
    void CloseRightAnswerCard()
    {
        rightAnswerCard.SetActive(false);       
    }

    // Method to close the wrong answer card and show the red exclamation mark
    void CloseWrongAnswerCard()
    {
        wrongAnswerCard.SetActive(false);       
        exclamationMarkRed.SetActive(true);     
    }

    // Method to orient a given card towards the player
    void OrientCardTowardsPlayer(GameObject card)
    {
        Vector3 directionToPlayer = playerCamera.position - card.transform.position; // Calculate direction to the player
        directionToPlayer.y = 0; // Optional: Keep the card's height unchanged
        card.transform.rotation = Quaternion.LookRotation(directionToPlayer) * Quaternion.Euler(0, 180, 0); // Set the card's rotation
    }
}
