using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System;
using System.Collections.Specialized;

public class Four : Objet
{
    public Transform[] listeDestinations = new Transform[4];
    public List<MiniObjet> listeCasseroles = new List<MiniObjet>();
    public bool[] listeDestinationsLibres = new bool[4];
    public int nombreObjetsEnFeu;
<<<<<<< HEAD:Projet/Assets/Scripts/Scripts Classes/Four.cs
    public List<CuissonHandler> listeCanvas= new List<CuissonHandler>();
=======
    public List<CuissonHandler> listeCanvas = new List<CuissonHandler>();
>>>>>>> master:Projet/Assets/Scripts/ScriptsClasses/Four.cs

    //Lui c'est le bon
    // Update is called once per frame
    void Update()
    {
        //TODO: Si une MiniObjet est en feu faire que les casseroles adjacecntes réchauffe plus vite

        //Augmenter la température des objets entrain de cuire et les faire brûler
        foreach (MiniObjet miniObjet in listeCasseroles)
        {
            if (miniObjet != null)
            {
                miniObjet.cuisson += Time.deltaTime * (nombreObjetsEnFeu + 1); //Augmenter la cuisson de l'objet
            }
        }

        //Vérifier si les objets sont encore là
        List<MiniObjet> listeTemporaire = listeCasseroles;
        for (int i = 0; i < listeTemporaire.Count; i++)
        {
            if (!listeCasseroles[i].estEntrainDeCuire)
            {
                listeCasseroles.Remove(listeCasseroles[i]);
                listeDestinationsLibres[i] = false;
            }
        }

        //Modifer la barre de cuisson
<<<<<<< HEAD:Projet/Assets/Scripts/Scripts Classes/Four.cs
        for (int i=0;i<listeCanvas.Count;i++)
=======
        for (int i = 0; i < listeCanvas.Count; i++)
>>>>>>> master:Projet/Assets/Scripts/ScriptsClasses/Four.cs
        {
            if (listeDestinationsLibres[i])
            {
                listeCanvas[i].SetCuissonBarValue(listeCasseroles[i].cuisson / 30.0f);
<<<<<<< HEAD:Projet/Assets/Scripts/Scripts Classes/Four.cs
            } else
            {
                listeCanvas[i].SetCuissonBarValue(0);
            }
        }
    
=======
            }
            else
            {
                listeCanvas[i].SetCuissonBarValue(0);
            }
>>>>>>> master:Projet/Assets/Scripts/ScriptsClasses/Four.cs
        }

    }

    override
    public void utiliser()
    {
    }

    override
    public Transform interaction(GameObject destination)
    {
        MiniObjet scriptMiniObjet = null;
        if (destination != null)
        {
            //Trouver le script de l'objet que le joueur tien dans ses mains
            Joueur scriptJoueur = null;
            scriptJoueur = trouverInteraction(destination.transform, scriptJoueur);

            scriptMiniObjet = trouverInteraction(scriptJoueur.objetTenu, scriptMiniObjet);
        }

        if (scriptMiniObjet != null) //Le joueur tient un objet
        {
            for (int i = 0; i < listeDestinationsLibres.Length; i++)
            {
                if (!listeDestinationsLibres[i])
                {
                    listeDestinationsLibres[i] = true;
                    deplacerMiniObjet(listeDestinations[i], scriptMiniObjet);
                    listeCasseroles.Add(scriptMiniObjet);
                    scriptMiniObjet.estEntrainDeCuire = true;
                    return scriptMiniObjet.transform;
                }
            }
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

    //Deplacer la MiniObjet à cet endroit
    private void deplacerMiniObjet(Transform destination, MiniObjet miniObjet)
    {
        Vector3 initialScale = miniObjet.gameObject.transform.localScale;
        destination.parent = null;
        destination.localScale = new Vector3(1, 1, 1);
        miniObjet.gameObject.transform.parent = destination;
        destination.SetParent(transform, true);
        miniObjet.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        miniObjet.gameObject.layer = 8;
        miniObjet.gameObject.tag = "ObjetTenu";
        miniObjet.gameObject.transform.position = destination.position + destination.up;
        miniObjet.gameObject.GetComponent<Collider>().isTrigger = false;
        miniObjet.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
