using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigo : Objet
{
    public float tempsAvantRafrichissement;
    public List<GameObject> inventaire; //Liste d'objets dans le frigo
    public bool estOuvert; //Vérifie si le frigo est ouvert ou non
    public List<Transform> listeDestinations; //Endroits où les aliments apparaitront
    public GameObject[] listePrefabsNourriture; //Liste des aliments qui peuvent se trouver dans le frigo
    private float temps=0; //Compteur avant de rafraichir tous les aliments
    public float distanceInfluence; //Rayon pour que le frigo puisse faire disparaitre un objet
    private Animation animation;

    void Start()
    {
        animation = gameObject.GetComponent<Animation>();
        estOuvert = false;
        remplir();

    }

    // Update is called once per frame
    void Update()
    {
        if (temps < tempsAvantRafrichissement ) //Vérifie si on a dépassé 30 secondes 
        {
            temps += Time.deltaTime;//Incrémente le temps de 1 frame (Quantité change dépendemment de la puissance de l'ordinateur)
        } else //Le temps a dépassé 30 secondes
        {
            temps = 0; //Reset le timer
            rafraichir(); //Rafraichir tous les aliments du frigo
        }
    }
    override
    public void utiliser()
    {
    }
    override
    public Transform interaction(GameObject destination)
    {
        if (estOuvert)
        {
            animation.Play("fermeturePorte");
            estOuvert = false;
        } else
        {
            animation.Play("ouverturePorte");
            estOuvert = true;
        }
        rafraichir();
        return null;
    }   

    private void rafraichir()
    {
        effacerContenu(); //Effacer le contenu de la liste
        remplir(); //Remplir le frigo
    }

    private void effacerContenu() //Efface le contenu du frigo
    {
        GameObject[] listeNourritureAEffacer = GameObject.FindGameObjectsWithTag("NourritureFrigo");
        Debug.Log(listeNourritureAEffacer.Length);
        foreach (GameObject nourriture in listeNourritureAEffacer)
        {
            if (Vector3.Distance(nourriture.transform.position, transform.position)< distanceInfluence)
            {
                Destroy(nourriture);
            }
        }
        inventaire.Clear();
    }

    private void approvisionner(float choix, Vector3 position)
    {
        if (choix < 30) //SPAM 30%
        {
            GameObject copieNourriture = (GameObject)Instantiate(listePrefabsNourriture[0], position, Quaternion.identity);
            inventaire.Add(copieNourriture);
        } else if(choix <40) //Radis 10%
        {
            GameObject copieNourriture = (GameObject)Instantiate(listePrefabsNourriture[1], position, Quaternion.identity);
            inventaire.Add(copieNourriture);
        } else if (choix <50) //Brocoli 10%
        {
            GameObject copieNourriture = (GameObject)Instantiate(listePrefabsNourriture[2], position, Quaternion.identity);
            inventaire.Add(copieNourriture);
        } else if (choix <55) //Chocolat 5%
        {
            GameObject copieNourriture = (GameObject)Instantiate(listePrefabsNourriture[3], position, Quaternion.identity);
            inventaire.Add(copieNourriture);
        } else if(choix <60) //Fromage 5%
        {
            GameObject copieNourriture = (GameObject)Instantiate(listePrefabsNourriture[4], position, Quaternion.identity);
            inventaire.Add(copieNourriture);
        } else if (choix <70) //Chaussure 10%
        {
            GameObject copieNourriture = (GameObject)Instantiate(listePrefabsNourriture[5], position, Quaternion.identity);
            inventaire.Add(copieNourriture);
        } else if (choix <90) //Boite de Conserve 20%
        {
            GameObject copieNourriture = (GameObject)Instantiate(listePrefabsNourriture[6], position, Quaternion.identity);
            inventaire.Add(copieNourriture);
        }
    }

    private void remplir()
    {
        foreach (Transform destination in listeDestinations) //Pour chaque destination on ajoute un nourriture
        {
            approvisionner(Random.value * 100, destination.position); //Faire apparaitre une nourriture choisi au hasard à la position de la destination
            Debug.Log("Approvisionenement");
        }
    }

     

    


}
