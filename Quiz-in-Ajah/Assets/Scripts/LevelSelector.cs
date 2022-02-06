using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] GameObject topicCanvas;
    [SerializeField] GameObject levelCanvas;

    [SerializeField] List<Button> levelButtons = new List<Button>();
    [SerializeField] Color32 levelLocked = new Color32(150, 150, 150, 255);

    void Start()
    {
        topicCanvas.SetActive(true);
        levelCanvas.SetActive(false);

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Count; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;

                Image buttonImage = levelButtons[i].GetComponent<Image>();
                buttonImage.color = levelLocked;
            }
        }
    }

    public void SelectLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ShowLevelSelect()
    {
        topicCanvas.SetActive(false);
        levelCanvas.SetActive(true);
    }

    public void ShowTopicSelect()
    {
        topicCanvas.SetActive(true);
        levelCanvas.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
