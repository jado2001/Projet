using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public bool estAssome;
    public float jaugeDeVie, jaugeDeFaim, vitesse;
    public Transform objetTenu;
    public float range; 

    void Update()
    {
        //Acceder au joueur à travers Destination --> Camera --> Joueur
        Transform joueur = (gameObject.transform.parent).parent;
        //Acceder au script ActionJoueur du joueur pour ensuite prendre l'objetTenu et l'ajouter dans l'inventaire
        objetTenu = joueur.gameObject.GetComponent<ActionJoueur>().objetTenu;
    }
}
