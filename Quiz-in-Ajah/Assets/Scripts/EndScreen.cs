using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI conditionsTitle;
    [SerializeField] TextMeshProUGUI gameConditionsText;

    [SerializeField] TMP_ColorGradient winConditionGradient;
    [SerializeField] TMP_ColorGradient loseConditionGradient;

    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject restartButton;

    public void WinCondition()
    {
        conditionsTitle.text = "CONGRATULATIONS !";
        gameConditionsText.text = "YOU WIN !";

        gameConditionsText.colorGradientPreset = winConditionGradient;
        nextLevelButton.SetActive(true);
        restartButton.SetActive(false);
    }

    public void LoseCondition()
    {
        conditionsTitle.text = "NICE TRY, NICE TRY !";
        gameConditionsText.text = "YOU LOSE !";

        gameConditionsText.colorGradientPreset = loseConditionGradient;
        nextLevelButton.SetActive(false);
        restartButton.SetActive(true);
    }
}
