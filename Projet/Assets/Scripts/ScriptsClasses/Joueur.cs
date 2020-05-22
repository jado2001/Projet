using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Joueur : MonoBehaviour
{
    public bool estAssome;
    public float jaugeDeVie, jaugeDeFaim, vitesse;
    public Transform objetTenu;
    public float range; 

    private void Start()
    {
        jaugeDeVie = 100;
        InvokeRepeating("diminuerFaim", 2.0f, 120f);
    }


    void Update()
    {
        
        //Acceder au joueur à travers Destination --> Camera --> Joueur
        Transform joueur = (gameObject.transform.parent).parent;
        //Acceder au script ActionJoueur du joueur pour ensuite prendre l'objetTenu et l'ajouter dans l'inventaire
        objetTenu = joueur.gameObject.GetComponent<ActionJoueur>().objetTenu;
        if (jaugeDeVie <= 0)
        {
            SceneManager.LoadScene(5);///Envoie le joueur à la scène du Game Over
            Debug.Log("Ye mort");
        }
        
        
    }

    /// <summary>
	/// sert à faire diminuer la faim du joueur aléatoirement
	/// </summary>
    public void diminuerFaim()
    {
        jaugeDeFaim = jaugeDeFaim - (Random.Range(1, 10));
    }

}
