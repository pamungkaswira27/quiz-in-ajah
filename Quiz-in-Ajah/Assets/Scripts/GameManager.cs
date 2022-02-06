using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;
    ScoreKeeper scoreKeeper;

    [SerializeField] int maxLevelAvailable = 5;

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

                int currentUnlockLevel = PlayerPrefs.GetInt("levelReached");

                if (currentUnlockLevel < maxLevelAvailable)
                {
                    PlayerPrefs.SetInt("levelReached", currentUnlockLevel + 1);
                    gameObject.SetActive(false);
                }
                else
                {
                    PlayerPrefs.SetInt("levelReached", maxLevelAvailable);
                    gameObject.SetActive(false);
                }
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

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
