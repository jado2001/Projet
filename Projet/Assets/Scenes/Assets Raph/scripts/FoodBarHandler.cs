using UnityEngine;
using UnityEngine.UI;

public class FoodBarHandler : MonoBehaviour
{
    private static Image FoodBarImage;

    /// <summary>
    /// Sets the health bar value
    /// </summary>
    /// <param name="value">should be between 0 to 1</param>
    public static void SetFoodBarValue(float value)
    {
        FoodBarImage.fillAmount = value;
        if (FoodBarImage.fillAmount < 0.2f)
        {
            SetFoodBarColor(Color.red);
        }
        else if (FoodBarImage.fillAmount < 0.4f)
        {
            SetFoodBarColor(Color.yellow);
        }
        else
        {
            SetFoodBarColor(Color.green);
        }
    }

    public static float GetFoodBarValue()
    {
        return FoodBarImage.fillAmount;
    }

    /// <summary>
    /// Sets the health bar color
    /// </summary>
    /// <param name="foodColor">Color </param>
    public static void SetFoodBarColor(Color foodColor)
    {
        FoodBarImage.color = foodColor;
    }

    /// <summary>
    /// Initialize the variable
    /// </summary>
    private void Start()
    {
        FoodBarImage = GetComponent<Image>();
    }
}