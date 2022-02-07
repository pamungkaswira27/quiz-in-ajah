using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;
    ScoreKeeper scoreKeeper;

    [Header("Current Level")]
    [SerializeField] int currentLevel = 1;

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);

        gameObject.SetActive(true);
    }

    void Update()
    {
        if (quiz.isComplete)
        {
            if (scoreKeeper.GetCorrectAnswers() >= 4)
            {
                endScreen.WinCondition();

                quiz.gameObject.SetActive(false);
                endScreen.gameObject.SetActive(true);

                PlayerPrefs.SetInt("levelReached", currentLevel + 1);
            }
            else
            {
                endScreen.LoseCondition();

                quiz.gameObject.SetActive(false);
                endScreen.gameObject.SetActive(true);
            }
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
