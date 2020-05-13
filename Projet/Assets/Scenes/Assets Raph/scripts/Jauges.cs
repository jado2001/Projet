﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauges : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FoodBarHandler.SetFoodBarValue(1);
        HealthBarHandler.SetHealthBarValue(1);
    }

    // Update is called once per frame
    void Update()
    {
        FoodBarHandler.SetFoodBarValue(FoodBarHandler.GetFoodBarValue() - 0.01f);
        HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() - 0.01f);
    }
}
