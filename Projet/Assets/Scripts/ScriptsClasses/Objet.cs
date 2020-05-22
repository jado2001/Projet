using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objet : MonoBehaviour
{
    public float tailleRamasse, layerObjet, durabilitee;
    public abstract Transform interaction(GameObject destination);
    public Behaviour halo;/// le halo d'un objet
    public abstract void utiliser();


    /// <summary>
	/// sert à faire apparaître le halo qui indique qu'on objet peut être une cible d'interaction
	/// </summary>
    void OnMouseOver()
    {
        halo = (Behaviour)GetComponent("Halo");
        if (halo != null)
        {
            halo.enabled = true;
        }

    }

    /// <summary>
	/// sert à enlever le halo qui indique qu'on objet peut être une cible d'interaction
	/// </summary>
    void OnMouseExit()
    {
        halo = (Behaviour)GetComponent("Halo");
        if (halo != null)
        {
            halo.enabled = false;
        }

    }
}
