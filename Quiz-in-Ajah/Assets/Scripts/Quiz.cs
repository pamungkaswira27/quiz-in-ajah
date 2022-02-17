using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    bool hasAnsweredEarly = true;
    int correctAnswerIndex;

    [Header("Answer Button Sprites")]
    [SerializeField] Sprite defaultButtonSprite;
    [SerializeField] Sprite correctButtonSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    [SerializeField] TextMeshProUGUI timerText;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Feedback")]
    [SerializeField] GameObject correctFeedback;
    [SerializeField] GameObject wrongFeedback;

    AudioManager audioManager;

    public bool isComplete;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        timerText.text = timer.GetTimerText();

        if (timer.loadNextQuestion)
        {
            if (questions.Count == 0)
            {
                isComplete = true;
                Debug.Log("Complete");
                return;
            }

            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = scoreKeeper.CalculateScore().ToString();
    }

    public int GetQuestionsCount()
    {
        return questions.Count;
    }

    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestion();

            scoreKeeper.IncrementQuestionPassed();
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }

        correctFeedback.SetActive(false);
        wrongFeedback.SetActive(false);
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            audioManager.PlayAudio("CorrectSFX");
            correctFeedback.SetActive(true);

            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctButtonSprite;

            scoreKeeper.IncrementCorrectAnswers();
            Debug.Log("Correct");
        }
        else
        {
            audioManager.PlayAudio("WrongSFX");
            wrongFeedback.SetActive(true);

            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();

            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctButtonSprite;
            Debug.Log("Wrong");
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultButtonSprite;
        }
    }
}
