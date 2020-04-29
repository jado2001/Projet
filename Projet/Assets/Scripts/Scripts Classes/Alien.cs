using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Alien : Objet
{
    public Transform joueur;

    public NavMeshAgent agent;

    private float rotation;

    private bool hasTask = true;

    public Porte porteActive = null;

    private bool isCoroutineExecuting = false;

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
    void Update()
    {
        // Debug.Log(porteActive);

        Debug.DrawRay(transform.position, transform.forward * 100, Color.green);
        RaycastHit hit; //Création d'un hit pour le Raycast
        Vector3 vecteurDirection = joueur.position - transform.position; //Vecteur entre le joueur et l'alien
        if (Physics.Raycast(transform.position, vecteurDirection / vecteurDirection.magnitude, out hit) && hit.transform.gameObject.layer == joueur.gameObject.layer) //Si le ray entre l'alien et le joueur touche qqch et que se qqch est le joueur
        {
            agent.SetDestination(joueur.position); //Dit à l'alien d'aller à la position du joueur
            porteActive = null;
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit) && hit.transform.gameObject.layer == 12)//Si le ray partant en avant de l'alien touche une porte
        {

            porteActive = trouverInteraction(hit.transform,porteActive);//Set la porte qu'il regarde comme la porteActive (l'objet au hit) 
            Vector3 vecteurPorte = (transform.position - porteActive.gameObject.transform.position); //Vecteur entre la porte et l'alien
            Vector3 vecteurDifference = vecteurPorte;
            vecteurDifference.Normalize();
            agent.SetDestination((porteActive.transform.position) + (vecteurDifference)); //Set la destination de l'alien à la porteActive
            transform.rotation = Quaternion.LookRotation(porteActive.transform.position - transform.position);
            
        }
        else if (porteActive != null && (transform.position - porteActive.gameObject.transform.position).magnitude <= 3)
        {
            transform.rotation = Quaternion.LookRotation(porteActive.transform.position - transform.position);
            Debug.Log("penis");
            StartCoroutine(executeAfterTime(2));
        }
        else if (agent.velocity.magnitude == 0 && porteActive == null)//si l'alien ne bouge pas et qu'il n'a pas de porteActive
        {

            rotation = rotation + .5f; //Change la valeur de la rotation
            transform.localRotation = Quaternion.Euler(0f, rotation, 0f);//Fait tourner l'alien sur lui-même

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

    public IEnumerator executeAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);
        if (porteActive != null)
        {
            porteActive.durabilitee--;
        }
        isCoroutineExecuting = false;
    }
}
