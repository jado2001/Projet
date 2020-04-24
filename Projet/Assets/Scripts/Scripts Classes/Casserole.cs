using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Casserole : MiniObjet
{
    public bool estRemplie;
    public bool estSale;
    public Transform contenu;



    override
        public void utiliser()
    {

    }
    override
    public Transform interaction(GameObject destination)  // méthode
    {
        Nourriture scriptNourriture = null;
        if (destination != null)
        {

            Joueur scriptJoueur = null;
            scriptJoueur = trouverInteraction(destination.transform, scriptJoueur); // prendre le script du joueur
                                                                                    //pour laver casserole ou remplir
            scriptNourriture = trouverInteraction(scriptJoueur.objetTenu, scriptNourriture);
        }

        if (scriptNourriture != null)
        {
            //Ramasser l'objet
            scriptNourriture.gameObject.transform.parent = transform;
            scriptNourriture.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            scriptNourriture.gameObject.layer = 11;
            scriptNourriture.gameObject.tag = "ObjetTenu";
            scriptNourriture.gameObject.transform.position = transform.position + transform.up;
            scriptNourriture.gameObject.GetComponent<Collider>().isTrigger = true;
            scriptNourriture.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            contenu = scriptNourriture.gameObject.transform;
            return scriptNourriture.gameObject.transform;
        }
        else
        {
            layerObjet = transform.gameObject.layer;
            //Ramasser l'objet
            transform.position = destination.transform.position;
            transform.localScale = transform.localScale * tailleRamasse;
            transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = destination.transform;
            transform.localRotation = new Quaternion(0, 0, 0, 0);
            gameObject.layer = 11;
            return transform;
        }

        return null;
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
