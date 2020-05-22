using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

/// <summary>
/// Classe qui gère le comportement de la porte 
/// </summary>
public class Porte : Objet
{
    public float movementSpeed = -10f, distanceAParcourir=3f;//Variables de Objet
    public float distanceTravelled = 0;
    public Vector3 lastPosition;
    public Vector3 startPos; //Variables de Objet
    public bool ouvert, estEnMouvement; //si la porte est ouverte, si la porte est en train de bouger
    public GameObject porteDetruite; //le modèle de la porte lorsqu'elle est détruite

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

    override
    public void utiliser()
    {
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
    public void ouvrir()
    {
        if (!estEnMouvement)
        {
            movementSpeed = -movementSpeed;
            estEnMouvement = true;
        }
    }
    /// <summary>
    /// Méthode pour bouger la porte
    /// </summary>
    void mouvement()
    {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
    }
    /// <summary>
    /// Méthode qui remplace la porte
    /// </summary>
    void remplacerPorte()
    {
        
       GameObject PorteDetruite = Instantiate(porteDetruite, transform.position, Quaternion.identity) as GameObject; //créé un nouvel objet avec le modèle de la porte détruite
        Destroy(gameObject);//Détruit la porte originale
    }

}
