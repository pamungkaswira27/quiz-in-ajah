using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI conditionsTitle;
    [SerializeField] TextMeshProUGUI gameConditionsText;

    [SerializeField] TMP_ColorGradient winConditionGradient;
    [SerializeField] TMP_ColorGradient loseConditionGradient;

    public void WinCondition()
    {
        conditionsTitle.text = "CONGRATULATIONS !";
        gameConditionsText.text = "YOU WIN !";

        gameConditionsText.colorGradientPreset = winConditionGradient;
    }

    public void LoseCondition()
    {
        conditionsTitle.text = "NICE TRY, NICE TRY !";
        gameConditionsText.text = "YOU LOSE !";

        gameConditionsText.colorGradientPreset = loseConditionGradient;
    }
}
