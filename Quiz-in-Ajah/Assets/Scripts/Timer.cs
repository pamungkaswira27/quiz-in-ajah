using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Time Limit")]
    [SerializeField] float timeToAnswerQuestion = 15f;
    [SerializeField] float timeToShowCorrectAnswer = 5f;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;
    
    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    public string GetTimerText()
    {
        return Mathf.RoundToInt(timerValue).ToString();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToAnswerQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                loadNextQuestion = true;
                isAnsweringQuestion = true;
                timerValue = timeToAnswerQuestion;
            }
        }
    }
}
