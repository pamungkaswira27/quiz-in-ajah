using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] DataController dataController;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] Button pauseButton;
    [SerializeField] Slider volumeSlider;

    public static bool isGamePaused;

    void Start()
    {
        volumeSlider.value = dataController.LoadVolumeSettings();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
}
