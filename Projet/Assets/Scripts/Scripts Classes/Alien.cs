using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

using Random = UnityEngine.Random;

public class Alien : Objet
{
    public Joueur joueur;

    public NavMeshAgent agent;

    private float rotation;

    public Porte porteActive = null;

    private float tempsRestant;

    private float tempsIdle;


    override
    public Transform interaction(GameObject destination)
    {
        return null;
    }
    override
        public void utiliser()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        verComportement(2);

    }

    public void verComportement(float dommage)
    {

        Debug.DrawRay(transform.position, transform.forward * 100, Color.green);
        RaycastHit hit; //Création d'un hit pour le Raycast
        Vector3 vecteurDirection = joueur.transform.parent.parent.position - transform.position; //Vecteur entre le joueur et l'alien
        if (Physics.Raycast(transform.position, vecteurDirection / vecteurDirection.magnitude, out hit) && hit.transform.gameObject.layer == joueur.gameObject.layer) //Si le ray entre l'alien et le joueur touche qqch et que se qqch est le joueur
        {
            agent.SetDestination(joueur.transform.parent.parent.position); //Dit à l'alien d'aller à la position du joueur
            porteActive = null;
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit) && hit.transform.gameObject.layer == 12)//Si le ray partant en avant de l'alien touche une porte
        {

            porteActive = trouverInteraction(hit.transform, porteActive);//Set la porte qu'il regarde comme la porteActive (l'objet au hit) 
            Vector3 vecteurPorte = (transform.position - porteActive.gameObject.transform.position); //Vecteur entre la porte et l'alien
            Vector3 vecteurDifference = vecteurPorte;
            vecteurDifference.Normalize();
            agent.SetDestination((porteActive.transform.position) + (vecteurDifference)); //Set la destination de l'alien à la porteActive
            transform.rotation = Quaternion.LookRotation(porteActive.transform.position - transform.position);

        }

        else if (agent.velocity.magnitude == 0 && porteActive == null)//si l'alien ne bouge pas et qu'il n'a pas de porteActive
        {

            rotation = rotation + .5f; //Change la valeur de la rotation
            transform.localRotation = Quaternion.Euler(0f, rotation, 0f);//Fait tourner l'alien sur lui-même
            tempsIdle += Time.deltaTime; //incrémente le temps du temps que le frame a pris
            if (tempsIdle >= 10)//si sa fait 10 secondes que l'alien a pas bouger
            {
                agent.SetDestination(RandomNavmeshLocation(20f)); //set la destination de l'alien un point aléatoire de 20 de rayon                
                tempsIdle = 0;//reset le tempsIdle
            }
        }
        if ((transform.position - joueur.transform.parent.parent.position).magnitude <= 3)
        {
            attaquerJoueur(1, dommage);
        }
        if (porteActive != null && (transform.position - porteActive.gameObject.transform.position).magnitude <= 3) //si la porteActive est a moins de 3
        {

            transform.rotation = Quaternion.LookRotation(porteActive.transform.position - transform.position);//regarde la porte
            attaquerPorte(1, dommage);//attaque la porte
        }

    }

    private T trouverInteraction<T>(Transform hit, T objetType) where T : MonoBehaviour
    {
        //Aller a travers la liste des scripts de l'objet pour utiliser celui qui possede interaction
        var listeComponents = hit.gameObject.GetComponents(typeof(T));
        foreach (T script in listeComponents)
        {
            try
            {
                return script;
            }
            catch (Exception e)
            {
            }
        }
        return null;
    }
    public void attaquerPorte (float time, float dommage)
    {
        if (tempsRestant >= time) //si sa fait plus que "time" secondes
        {
            porteActive.durabilitee=porteActive.durabilitee-dommage;//réduit la durabilité de la porte

            tempsRestant = 0; //reset le tempsRestants
        }
        else
        {
            tempsRestant += Time.deltaTime;//ajout le temps de la frame
        }
    }

    public void attaquerJoueur(float time, float dommage)
    {
        if (tempsRestant >= time) //si sa fait plus que "time" secondes
        {
            joueur.jaugeDeVie=joueur.jaugeDeVie-dommage;//réduit la durabilité de la porte           
            Debug.Log("Ayoille donc caliss");
            tempsRestant = 0; //reset le tempsRestants
        }
        else
        {
            tempsRestant += Time.deltaTime;//ajout le temps de la frame
        }
    }
    public Vector3 RandomNavmeshLocation(float radius)//trouve un point aléatoire de "radius" de rayon
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius; //vecteur aléatoire
        randomDirection += transform.position;//vecteur aléatoire à partir de l'alien
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }


}