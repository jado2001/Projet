using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Couteau : MiniObjet
{
    private float rangeJoueur;
    public float x;
    public float y;
    public float z;
    public float w;
    private Camera cameraJoueur;
    override
    public Transform interaction(GameObject destination)
    {
        Joueur scriptJoueur = null;
        scriptJoueur = trouverInteraction(destination.transform, scriptJoueur);
        rangeJoueur = scriptJoueur.range;
        gameObject.tag = "Untagged";
        layerObjet = transform.gameObject.layer;
        //Ramasser l'objet
        transform.position = destination.transform.position;
        cameraJoueur = destination.transform.parent.gameObject.GetComponent<Camera>();
        transform.localScale = transform.localScale * tailleRamasse;
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = destination.transform;
        transform.localRotation = new Quaternion(x, y, z, w);
        gameObject.layer = 11;

        return transform;
    }
    override
    public void utiliser()
    {
        int layerMask = 1 << 10 | 1 << 9 | 1 << 11 | 1 << 0;


        layerMask = ~layerMask;

        RaycastHit hit;



        if (Physics.Raycast(cameraJoueur.transform.position, cameraJoueur.transform.forward, out hit, rangeJoueur, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");

            MiniObjet script = null;
            script = trouverInteraction(hit.transform, script);
            try
            {
                script.estCoupe = true; // rend le mini objet coupé
            }
            catch (Exception e)
            {

            }

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
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



    // Update is called once per frame


}
