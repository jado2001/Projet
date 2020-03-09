 using UnityEngine;
using System;

public class ActionJoueur : MonoBehaviour
{
    public float range;
    public Camera camera;
    public Transform objetTenu=null;
    public Transform destination;
    public float forceDeLancer,tailleRamasse,layerObjet;
    //Liste de tous les scripts présents dans le jeu



    //Méthode Start
    void Start()
    {
        //Initialiser les scripts
        Debug.Log("Boogieman");
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Interagir();
        } else if (Input.GetButtonDown("Fire2"))
        {
            Lancer();
        }
    }

    void Interagir()
    {
        int layerMaskSansInteraction=1<<10 | 1<<9 | 1 << 11 | 1 << 0;
        layerMaskSansInteraction = ~layerMaskSansInteraction;
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range, layerMaskSansInteraction ) )
        {
            Debug.DrawRay(camera.transform.position, camera.transform.forward, Color.red);
            //Sauvegarde
            Transform sauvegarde=null;
            //Sauvegarder le premier objet Tenu + Lâcher l'objet
            if (objetTenu !=null)
            {
            sauvegarde = objetTenu;
            lacher();
            }
            //Aller a travers la liste des scripts de l'objet pour utiliser celui qui possede interaction
            var listeComponents = hit.transform.gameObject.GetComponents(typeof(MonoBehaviour));
            foreach (MonoBehaviour script in listeComponents)
            {
                try
                {
                    //Cast le script en Objet pour appeler la méthode Intéragir
                    Objet objet = (Objet)script;
                    objetTenu= objet.interaction(destination.gameObject);
                    tailleRamasse = objet.tailleRamasse; //Prendre la taille de l'objet
                    layerObjet = objet.layerObjet;
                    Debug.Log(layerObjet);
                } catch(Exception e)
                {
                }
            }
            Debug.Log("Objet ramassé:"+hit.transform.name);
            //Vérifier si un nouvel objet est Tenu
            if (objetTenu == null)
            {
                objetTenu = sauvegarde;
            }
            
        }
    }

    void Lancer()
    {

        objetTenu.gameObject.GetComponent<Rigidbody>().isKinematic = false; //Redonner des physiques a l'objet
        objetTenu.gameObject.GetComponent<Rigidbody>().AddForce(destination.forward*forceDeLancer);
        lacher();

    }
    
    private void lacher()
    {
        objetTenu.gameObject.GetComponent<Rigidbody>().isKinematic = false; //Redonner des physiques a l'objet
        objetTenu.localScale = objetTenu.localScale / tailleRamasse;
        destination.DetachChildren();
        objetTenu.gameObject.layer = (int) layerObjet;
        objetTenu = null;
    }
}
