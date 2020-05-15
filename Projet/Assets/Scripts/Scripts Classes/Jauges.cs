using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// classe qui sert à gérer le fonctionnement des jauges
/// </summary>
public class Jauges : MonoBehaviour
{

    public Joueur joueur;///le joueur


    /// <summary>
	/// initialisation des jauges du joueur
	/// </summary>
    void Start()
    {
        FoodBarHandler.SetFoodBarValue(joueur.GetComponent<Joueur>().jaugeDeFaim);
        HealthBarHandler.SetHealthBarValue(joueur.GetComponent<Joueur>().jaugeDeVie);
    }

    // Update is called once per frame
    void Update()
    {
        FoodBarHandler.SetFoodBarValue(FoodBarHandler.GetFoodBarValue());
        HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue());
    }
}
