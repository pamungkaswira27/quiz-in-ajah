using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [Header("Game Conditions")]
    [SerializeField] TextMeshProUGUI conditionsTitle;
    [SerializeField] TextMeshProUGUI gameConditionsText;

    [Header("Color Gradients")]
    [SerializeField] TMP_ColorGradient winConditionGradient;
    [SerializeField] TMP_ColorGradient loseConditionGradient;

    [Header("Result Buttons")]
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
