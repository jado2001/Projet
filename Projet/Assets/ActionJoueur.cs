using UnityEngine;
using System;

public class ActionJoueur : MonoBehaviour
{
    public float range;
    public Camera camera;
    public Transform objetTenu=null;
    public Transform destination;
    public float forceDeLancer;
    private float tailleRamasse;
    //Liste de tous les scripts présents dans le jeu



    //Méthode Start
    void Start()
    {
        //Initialiser les scripts
        
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
        int layerMaskSansInteraction=1<<10 | 1<<9 | 1 << 11;
        layerMaskSansInteraction = ~layerMaskSansInteraction;
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range, layerMaskSansInteraction ) )
        {
            //Aller a travers la liste des scripts de l'objet pour utiliser celui qui possede interaction
            var listeComponents = hit.transform.gameObject.GetComponents(typeof(MonoBehaviour));
            foreach (MonoBehaviour script in listeComponents)
            {
                try
                {
                    MiniObjet miniObjet = (MiniObjet)script;
                    miniObjet.interaction(destination.gameObject);
                    tailleRamasse = miniObjet.tailleRamasse;
                } catch(Exception e)
                {
                }
            }
            Debug.Log("Objet ramassé:"+hit.transform.name);
            objetTenu = hit.transform;
            Debug.Log("Objet tenu:" + objetTenu.name);

        }
    }

    void Lancer()
    {

        objetTenu.gameObject.GetComponent<Rigidbody>().isKinematic = false; //Redonner des physiques a l'objet
        objetTenu.gameObject.GetComponent<Rigidbody>().AddForce(destination.forward*forceDeLancer); 
        objetTenu.localScale = objetTenu.localScale / tailleRamasse;
        destination.DetachChildren();
        objetTenu = null;

    }   
}
