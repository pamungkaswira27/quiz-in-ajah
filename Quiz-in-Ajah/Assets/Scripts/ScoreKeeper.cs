using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int questionPassed = 0;

    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public int GetQuestionPassed()
    {
        return questionPassed;
    }

    public void IncrementQuestionPassed()
    {
        questionPassed++;
    }

    public int CalculateScore()
    {
        return correctAnswers * 20;
    }
}
