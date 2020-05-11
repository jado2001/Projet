using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Table : Objet
{
    public GameObject swapObject;
    public Transform bol;
    public List<Transform> listeDestinations;
    public List<GameObject> listeNourriture;
    public GameObject prefabChaussure;
    public Mesh swapMesh;
    public List<Material> materiel;
    public bool plein;


    override
    public Transform interaction(GameObject destination)
    {
        Nourriture scriptNourriture = null;
        Casserole scriptCasserole = null;
        Joueur scriptJoueur = null;

        for (var i = listeNourriture.Count - 1; i > -1; i--)
        {
            if (listeNourriture[i] == null)
                listeNourriture.RemoveAt(i); // on enleve les items de nourritures qui ont été consommés
        }
        if (listeNourriture.Count == 0)
        {

            plein = false; // lorsque toute la nourriture sur la table est consommé, la table est vide
        }
        if (destination != null && !plein)
        {
            try
            {

                scriptJoueur = trouverInteraction(destination.transform, scriptJoueur);

                scriptCasserole = trouverInteraction(scriptJoueur.objetTenu, scriptCasserole);
                scriptNourriture = trouverInteraction(scriptCasserole.contenu, scriptNourriture);
            }
            catch (Exception e)
            {
                Debug.Log("erreur");
            }

            if (scriptNourriture != null && scriptCasserole.estRemplie && !scriptCasserole.estEnFeu && !scriptCasserole.estSale)
            {
                if (scriptCasserole.cuisson < 45 && scriptCasserole.cuisson >= 30)
                {
                    scriptNourriture.estPreparee = true;
                }
                else if (scriptCasserole.cuisson >= 45)
                {
                    scriptCasserole.contenu = prefabChaussure.transform;

                }


                scriptNourriture.gameObject.layer = 8; //change le layer de nourriture avant de le copier





                scriptNourriture.gameObject.transform.parent = transform;
                scriptNourriture.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
                scriptNourriture.gameObject.transform.position = transform.position + transform.up;
                scriptNourriture.gameObject.GetComponent<Collider>().isTrigger = true;
                scriptNourriture.gameObject.GetComponent<Rigidbody>().isKinematic = true;


                scriptNourriture.GetComponent<MeshFilter>().mesh = swapMesh; //change de mesh selon la nourriture
                                                                             //change le materiel
                if (scriptNourriture.faimRecuperee == 0 && scriptNourriture.vitesseRecuperee == 0)
                {
                    scriptNourriture.GetComponent<MeshRenderer>().material = materiel[0];
                    //boite de conserve
                }
                if (scriptNourriture.faimRecuperee == -15 && scriptNourriture.vitesseRecuperee == 0)
                {
                    scriptNourriture.GetComponent<MeshRenderer>().material = materiel[1];
                    //brocoli
                }
                if (scriptNourriture.faimRecuperee == 0 && scriptNourriture.vitesseRecuperee == 2)
                {
                    scriptNourriture.GetComponent<MeshRenderer>().material = materiel[2];
                    //chocolat
                }
                if (scriptNourriture.faimRecuperee == 100 && scriptNourriture.vitesseRecuperee == 0)
                {
                    scriptNourriture.GetComponent<MeshRenderer>().material = materiel[3];
                    //fromage
                }
                if (scriptNourriture.faimRecuperee == 50 && scriptNourriture.vitesseRecuperee == 0)
                {
                    scriptNourriture.GetComponent<MeshRenderer>().material = materiel[4];
                    //radis
                }
                if (scriptNourriture.faimRecuperee == 80 && scriptNourriture.vitesseRecuperee == 0)
                {
                    scriptNourriture.GetComponent<MeshRenderer>().material = materiel[5];
                    //spam
                }


                scriptNourriture.gameObject.transform.localScale = new Vector3(0.42f, 0.001f, 0.43f);


                foreach (Transform endroit in listeDestinations)
                {

                    GameObject clone = (GameObject)Instantiate(scriptNourriture.gameObject, endroit.position, Quaternion.identity); // on le copie 4 fois
                    clone.transform.parent = endroit.parent; //on dit a chaque nourriture de rester 
                    //on rajoute les objets nourritures a une liste de transform pourqu'ils apparaissent sur la table
                    listeNourriture.Add(clone);
                }

                Destroy(scriptNourriture.gameObject);

                plein = true;
            }
        }



        return null;
    }
    override
    public void utiliser()
    {

    }
    private T trouverInteraction<T>(Transform hit, T objetType) where T : MonoBehaviour
    {
        //Aller a travers la liste des scripts de l'objet pour utiliser celui qui possede interaction
        try
        {
            var listeComponents = hit.gameObject.GetComponents(typeof(T));
            foreach (T script in listeComponents)
            {

                return script;
            }

        }
        catch (Exception e)
        {
        }
        return null;
    }
}
