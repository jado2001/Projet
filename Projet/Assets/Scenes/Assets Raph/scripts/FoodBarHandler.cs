using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// sert à gérer l'affichage de la jauge de faim
/// </summary>
public class FoodBarHandler : MonoBehaviour
{
    private static Image FoodBarImage;///l'image de la jauge

    /// <summary>
    /// change l'apparence de la jauge en fonction de la valeur envoyée
    /// </summary>
    /// <param name="value">should be between 0 to 1</param> la valeur de la jauge
    public static void SetFoodBarValue(float value)
    {
        FoodBarImage.fillAmount = value;
        if (FoodBarImage.fillAmount <= 0.02f)
        {
            SetFoodBarColor(Color.red);
        }
        else if (FoodBarImage.fillAmount <= 0.05f)
        {
            SetFoodBarColor(Color.yellow);
        }
        else
        {
            SetFoodBarColor(Color.green);
        }
    }

    /// <summary>
	/// getter de la valeur de la jauge
	/// </summary>
	/// <returns></returns> la valeur de la jauge
    public static float GetFoodBarValue()
    {
        return FoodBarImage.fillAmount;
    }

    /// <summary>
    /// change la couleur de la jauge
    /// </summary>
    /// <param name="foodColor">Color </param> la couleur de la jauge
    public static void SetFoodBarColor(Color foodColor)
    {
        FoodBarImage.color = foodColor;
    }

    /// <summary>
    /// initialise l'image de la jauge
    /// </summary>
    private void Start()
    {
        FoodBarImage = GetComponent<Image>();
    }
}