using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuissonHandler : MonoBehaviour
{

    private Image FoodBarImage;
    // Start is called before the first frame update
    void Start()
    {
        FoodBarImage = GetComponent<Image>();
        FoodBarImage.fillAmount = 0f;
    }


    public void SetCuissonBarValue(float value)
    {
        //Modifier la taille de la bar
        if (value>=1)
        {
            FoodBarImage.fillAmount = 1f;
        } else
        {
            FoodBarImage.fillAmount = value;
        }

        //Modifier la couleure
        if (value<= 1f)
        {
            SetCuissonBarColor(Color.green);
        } else if(value>1f && value <= 1.5f)
        {
            SetCuissonBarColor(Color.yellow);
        } else
        {
            SetCuissonBarColor(Color.red);
        }


    }

    public float GetCuissonBarValue()
    {
        return FoodBarImage.fillAmount;
    }

    public void SetCuissonBarColor(Color foodColor)
    {
        FoodBarImage.color = foodColor;
    }
}
