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
        rightAnswer.onClick.AddListener(answeredRight);
        wrongAnswer.onClick.AddListener(answeredWrong);
        wrongAnswer2.onClick.AddListener(answeredWrong);
        wrongAnswer3.onClick.AddListener(answeredWrong);
        closeButtonWrongAnswer.onClick.AddListener(closeWrongAnswerCard);
        closeButtonRightAnswer.onClick.AddListener(closeRightAnswerCard);

        // Add voice output
        speech = GetComponent<LMNTSpeech>();
    }

    void OnMouseDown()
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

    void answeredRight()
    {
        checkBackCard.SetActive(false);
        rightAnswerCard.SetActive(true);
    }

    void answeredWrong()
    {
        checkBackCard.SetActive(false);
        wrongAnswerCard.SetActive(true);
    }

    void closeRightAnswerCard()
    {
        rightAnswerCard.SetActive(false);
    }

    void closeWrongAnswerCard()
    {
        wrongAnswerCard.SetActive(false);
        clickCount--;
        exclamationMarkGreen.SetActive(true);
    }
}
