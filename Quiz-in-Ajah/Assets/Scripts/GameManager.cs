using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;
    ScoreKeeper scoreKeeper;
    PauseMenu pauseMenu;

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
    }

    void Start()
    {
        AudioManager.instance.PlayAudio("GameplayBGM");
        AudioManager.instance.StopAudio("MenuBGM");

        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);

        //gameObject.SetActive(true);
    }

    void Update()
    {
        if (quiz.isComplete)
        {
            if (scoreKeeper.GetCorrectAnswers() >= 4)
            {
                //audioManager.PlayAudio("WinSFX");
                endScreen.WinCondition();

                quiz.gameObject.SetActive(false);
                endScreen.gameObject.SetActive(true);

                dataController.SaveLevelReached(currentLevel);
            }
            else
            {
                //audioManager.PlayAudio("LoseSFX");
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
