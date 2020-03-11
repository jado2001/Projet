using UnityEngine;
using System;

public class ActionJoueur : MonoBehaviour
{
    public float range;
    public Camera camera;
    public Transform objetTenu = null;
    public Transform destination;
    public float forceDeLancer, tailleRamasse, layerObjet, vie = 100, faim = 100, vitesse = 100;
    private Vector3 positionObjet = new Vector3(0f,0f,0f);
    //Liste de tous les scripts présents dans le jeu

/// <summary>
/// IL FAUT RÉGLER mANGER PENDANT QU'ON TIENT UN OBJET
/// </summary>
    //Méthode Start
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Interagir();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Lancer();
        }
    }

    void Interagir()
    {
        int layerMaskSansInteraction = 1 << 10 | 1 << 9 | 1 << 11 | 1 << 0;
        layerMaskSansInteraction = ~layerMaskSansInteraction;
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range, layerMaskSansInteraction))
        {
            
            //Sauvegarde
            Transform sauvegarde = null;
            positionObjet = hit.transform.position;
            //Sauvegarder le premier objet Tenu + Lâcher l'objet
            if (objetTenu != null)
            {
                sauvegarde = objetTenu;
            }
            //Aller a travers la liste des scripts de l'objet pour utiliser celui qui possede interaction
            var listeComponents = hit.transform.gameObject.GetComponents(typeof(Objet));
            foreach (Objet script in listeComponents)
            {
                try
                {
                    //Vérifier si l'objet intérragit est un 'Nourriture' dont le boolean estPreparee=true
                    if (script.GetType().Equals(typeof(Nourriture)))
                    {
                        Nourriture nourriture = (Nourriture)script;
                        if (nourriture.estPreparee)
                        {
                            //Modifier les stats du Joueur
                            vie = vie + nourriture.vieRecuperee;    
                            faim = faim + nourriture.faimRecuperee;
                            vitesse = vitesse + nourriture.vitesseRecuperee;
                            //Détruire l'objet
                            Destroy(hit.transform.gameObject);
                        }
                        else
                        {
                            if (objetTenu != null)
                            {
                                lacher();
                            }
                            
                            objetTenu = script.interaction(destination.gameObject); //*Prendre* l'objet
                            if (objetTenu != null)
                            {
                                tailleRamasse = script.tailleRamasse; //Prendre la taille de l'objet
                                layerObjet = script.layerObjet; //Prendre son layer
                            }
                        }
                    }
                    else
                    {
                        if (objetTenu != null)
                        {
                            lacher();
                        }
                        objetTenu = script.interaction(destination.gameObject); //*Prendre* l'objet
                        if (objetTenu != null)
                        {
                            tailleRamasse = script.tailleRamasse; //Prendre la taille de l'objet
                            layerObjet = script.layerObjet; //Prendre son layer
                        }
                    }
                }
                catch (Exception e)
                {
                }
            }
            Debug.Log("Objet ramassé:" + hit.transform.name);
            //Vérifier si un nouvel objet est Tenu
            if (objetTenu == null)
            {
                objetTenu = sauvegarde;
            } else
            {
                sauvegarde.position = positionObjet; //Déplacer l'objet tenu;
            }

        }
    }

    void Lancer()
    {

        objetTenu.gameObject.GetComponent<Rigidbody>().isKinematic = false; //Redonner des physiques a l'objet
        objetTenu.localRotation = new Quaternion(1, 2, 3, 0);
        objetTenu.gameObject.GetComponent<Rigidbody>().AddForce(destination.forward * forceDeLancer);
        lacher();

    }

    private void lacher()
    {
        objetTenu.gameObject.GetComponent<Rigidbody>().isKinematic = false; //Redonner des physiques a l'objet
        objetTenu.localScale = objetTenu.localScale / tailleRamasse;
        destination.DetachChildren();
        objetTenu.gameObject.layer = (int)layerObjet;
        objetTenu = null;
    }
}
