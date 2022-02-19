using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] DataController dataController;
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        AudioManager.instance.PlayAudio("MenuBGM");
        AudioManager.instance.StopAudio("GameplayBGM");

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
