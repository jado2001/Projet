using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// classe qui sert à gérer le fonctionnement des jauges
/// </summary>
public class Jauges : MonoBehaviour
{

    public Joueur joueur;///le joueur
    //Lui c'est le bon


    // Update is called once per frame

    void Update()
    {
        FoodBarHandler.SetFoodBarValue((joueur.GetComponent<Joueur>().jaugeDeFaim) / 100);
        HealthBarHandler.SetHealthBarValue((joueur.GetComponent<Joueur>().jaugeDeVie) / 100);
    }



}
