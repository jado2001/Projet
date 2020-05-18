using UnityEngine;
using System;
using System.Security.Cryptography;


public class ActionJoueur : MonoBehaviour
{
    private float range = 0;
    public Camera camera;
    public Transform objetTenu = null;
    public Transform destination;
    public float forceDeLancer, tailleRamasse, layerObjet;
    private Vector3 positionObjet = new Vector3(0f,0f,0f);
    public Joueur joueur;
    //Liste de tous les scripts présents dans le jeu

/// <summary>
/// IL FAUT RÉGLER mANGER PENDANT QU'ON TIENT UN OBJET
/// </summary>
    //Méthode Start
    void Start() 
    {
        range = joueur.range;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Interagir();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            utilisation();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            lancer();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            UnityEditor.EditorWindow.focusedWindow.maximized = !UnityEditor.EditorWindow.focusedWindow.maximized;
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
            //Trouver le script 
            Objet script = null;
            script= trouverInteraction(hit.transform, script);

            if (objetTenu != null)
            {
                lacher();
            }
                objetTenu = script.interaction(destination.gameObject); // Prendre/Intéragir avec l'objet
            if (objetTenu != null)
            {
                tailleRamasse = script.tailleRamasse; //Prendre la taille de l'objet
                layerObjet = script.layerObjet; //Prendre son layer
            }
            //Debug Log pour savoir quel objet est touché et si un objet est rammassé
            Debug.Log("Objet Touché:" + hit.transform.name);
            if (objetTenu!=null)
            {
                Debug.Log("Objet Rammassé:" + objetTenu.name);
            } else
            {
                Debug.Log("Objet Rammassé: Aucun");
            }

            //Vérifier si un nouvel objet est Tenu
            if (objetTenu == null && sauvegarde!=null)
            {
                script = trouverInteraction(sauvegarde, script);
                objetTenu = script.interaction(destination.gameObject); //*Prendre* l'objet
            } else if (sauvegarde!=null && objetTenu.gameObject.tag != "ObjetTenu")
            {
                sauvegarde.position = positionObjet; //Déplacer l'objet tenu;
            } else if (objetTenu.gameObject.tag == "ObjetTenu")
            {
                objetTenu = null;
            }

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

    void lancer()
    {
        objetTenu.gameObject.GetComponent<Rigidbody>().isKinematic = false; //Redonner des physiques a l'objet
        objetTenu.localRotation = new Quaternion(1, 2, 3, 0);
        objetTenu.gameObject.GetComponent<Rigidbody>().AddForce(destination.forward * forceDeLancer);
        MiniObjet script = null;
        script = trouverInteraction(objetTenu.transform, script);
        script.lancer();
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

    private void utilisation()
    {
        //Vérifier si on tien un objet
        if (objetTenu!=null)
        {
            Objet script = null;
            script = trouverInteraction(objetTenu, script);  //Trouver son script
            script.utiliser(); //Appeler sa méthode utiliser
        }
    }
}
