using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;
    ScoreKeeper scoreKeeper;
    PauseMenu pauseMenu;
    AudioManager audioManager;

    [Header("Data Controller")]
    [SerializeField] DataController dataController;

    [Header("Current Level")]
    [SerializeField] int currentLevel = 1;

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        audioManager.PlayAudio("GameplayBGM");
        audioManager.StopAudio("MenuBGM");

        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);

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

                dataController.SaveLevelReached(currentLevel);
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
