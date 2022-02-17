using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField] DataController dataController;
    [SerializeField] Slider volumeSlider;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        audioManager.PlayAudio("MenuBGM");
        audioManager.StopAudio("GameplayBGM");

        volumeSlider.value = dataController.LoadVolumeSettings();
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
