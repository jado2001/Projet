using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// sert à gérer l'affichage de la jauge de vie
/// </summary>
public class HealthBarHandler : MonoBehaviour
{
    private static Image HealthBarImage;///l'image de la jauge

    /// <summary>
    /// change l'apparence de la jauge en fonction de la valeur envoyée
    /// </summary>
    /// <param name="value">should be between 0 to 1</param> la valeur de la jauge
    public static void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
        if(HealthBarImage.fillAmount <= 0.02f)
        {
            SetHealthBarColor(Color.red);
        }
        else if(HealthBarImage.fillAmount <= 0.05f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    /// <summary>
	/// getter de la valeur de la jauge
	/// </summary>
	/// <returns></returns> la valeur de la jauge
    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }

    /// <summary>
    /// change la couleur de la jauge
    /// </summary>
    /// <param name="healthColor">Color </param> la couleur de la jauge
    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    /// <summary>
    /// initialise l'image de la jauge
    /// </summary>
    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
    }
}
