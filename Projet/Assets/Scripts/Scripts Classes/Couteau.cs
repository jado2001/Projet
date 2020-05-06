using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Couteau : MiniObjet
{


    override
    public void utiliser()
    {
        int layerMask = 1 << 10 | 1 << 9 | 1 << 11 | 1 << 0;


        layerMask = ~layerMask;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
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
