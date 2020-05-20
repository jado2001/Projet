using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Poubelle : Objet
{
    override
        public void utiliser()
    {

    }

    override
    public Transform interaction(GameObject destination)  // méthode
    {
        Joueur scriptJoueur = null;
        scriptJoueur = trouverInteraction(destination.transform,scriptJoueur); // prendre le script du joueur

        MiniObjet scriptMiniObjet = null;
        scriptMiniObjet = trouverInteraction(scriptJoueur.objetTenu, scriptMiniObjet);


        Destroy(scriptMiniObjet.gameObject);



        return null;

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

}
