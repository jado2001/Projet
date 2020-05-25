using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

/// <summary>
/// Classe qui gère le comportement de la porte 
/// </summary>
public class PorteEnHaut : Porte
{
   

    override
      public Transform interaction(GameObject destination)
    {
        return null;
    }
    void Start()
    {
        lastPosition = transform.position;
        durabilitee = 10;
    }

   
    /// <summary>
    /// Méthode appelée à toutes les frames
    /// </summary>
    void Update()
    {
        if (durabilitee <= 0) //Si la porte n'a plus de durabilité
        {

            remplacerPorte();//Remplace la porte
        }
        if (estEnMouvement)//si elle est en mouvement
        {
            mouvement();//bouge la porte
            if (distanceTravelled >= distanceAParcourir)//si il ne lui reste plus de distance à parcourir
            {
                distanceTravelled = 0;
                estEnMouvement = false;//arrete de bouger
            }
        }
    }
    /// <summary>
    /// Méthode pour ouvrir la porte
    /// </summary>
    /// 
    
    /// <summary>
    /// Méthode pour bouger la porte
    /// </summary>
    ///
    override
    public void mouvement()
    {
        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
    }
    /// <summary>
    /// Méthode qui remplace la porte
    /// </summary>
    /// 
   

}
