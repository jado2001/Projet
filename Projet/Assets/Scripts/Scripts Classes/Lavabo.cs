using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lavabo : Objet
{
    public bool estSavon;
    override
        public void utiliser()
    {

    }
    override
    public Transform interaction(GameObject destination)  // méthode
    {
        Joueur scriptJoueur = null;
        scriptJoueur = trouverInteraction(destination.transform, scriptJoueur); // prendre le script du joueur
                                                                        //pour laver casserole ou remplir
        Casserole scriptCasserole = null;
        scriptCasserole = trouverInteraction(scriptJoueur.objetTenu, scriptCasserole);

        if (scriptCasserole != null)
        {
            if (estSavon == true && scriptCasserole.estSale == true)
            {
                scriptCasserole.estSale = false;
                estSavon = false;
            }
            else if (scriptCasserole.estSale == false)
            {
                scriptCasserole.estRemplie = true;
            }
        }
        Savon scriptSavon = null;
        scriptSavon = trouverInteraction(scriptJoueur.objetTenu, scriptSavon);

        if (scriptSavon != null)
        {
            estSavon = true;
            Destroy(scriptSavon.gameObject);
        }

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
