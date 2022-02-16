using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        audioManager.PlayAudio("MenuBGM");
        audioManager.StopAudio("GameplayBGM");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuiGame()
    {
        Application.Quit();
        Debug.Log("Quit...");
    }
}
