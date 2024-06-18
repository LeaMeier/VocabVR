using LMNT;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
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
    private int clickCount = 1;
    private LMNTSpeech speech;

    void Start()
    {
        exclamationMarkRed.SetActive(true);
        exclamationMarkOrange.SetActive(false);
        exclamationMarkGreen.SetActive(false);
        readCard.SetActive(false);
        listenCard.SetActive(false);
        checkBackCard.SetActive(false);
        rightAnswerCard.SetActive(false);
        wrongAnswerCard.SetActive(false);

        // Add listeners to buttons
        closeButtonRead.onClick.AddListener(CloseReadCard);
        closeButtonListen.onClick.AddListener(CloseListenCard);
        listenButton.onClick.AddListener(PlayWord);
        rightAnswer.onClick.AddListener(AnsweredRight);
        wrongAnswer.onClick.AddListener(AnsweredWrong);
        wrongAnswer2.onClick.AddListener(AnsweredWrong);
        wrongAnswer3.onClick.AddListener(AnsweredWrong);
        closeButtonWrongAnswer.onClick.AddListener(CloseWrongAnswerCard);
        closeButtonRightAnswer.onClick.AddListener(CloseRightAnswerCard);

        // Add voice output
        speech = GetComponent<LMNTSpeech>();
    }

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
        if (clickCount == 1)
        {
            exclamationMarkRed.SetActive(false);
            readCard.SetActive(true);
        }

        if (clickCount == 2)
        {
            exclamationMarkOrange.SetActive(false);
            listenCard.SetActive(true);
        }

        if (clickCount == 3)
        {
            exclamationMarkGreen.SetActive(false);
            checkBackCard.SetActive(true);
            clickCount++;
        }
    }

    void CloseReadCard()
    {
        clickCount++;
        readCard.SetActive(false);
        exclamationMarkOrange.SetActive(true);
    }

    void CloseListenCard()
    {
        clickCount++;
        listenCard.SetActive(false);
        exclamationMarkGreen.SetActive(true);
    }

    void PlayWord()
    {
        StartCoroutine(speech.Talk());
    }

    void AnsweredRight()
    {
        checkBackCard.SetActive(false);
        rightAnswerCard.SetActive(true);
    }

    void AnsweredWrong()
    {
        checkBackCard.SetActive(false);
        wrongAnswerCard.SetActive(true);
    }

    void CloseRightAnswerCard()
    {
        rightAnswerCard.SetActive(false);
    }

    void CloseWrongAnswerCard()
    {
        wrongAnswerCard.SetActive(false);
        clickCount = 1;
        exclamationMarkGreen.SetActive(true);
    }
}
