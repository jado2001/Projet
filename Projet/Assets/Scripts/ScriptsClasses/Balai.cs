using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balai : MiniObjet
{
    public GameObject tuileActive;///tuile visée par le balai
    public Material matPropre;///material à appliquer sur les tuiles quand elles sont sales
    public float range;///portée du balai

    /// <summary>
    /// voir la méthode interaction dans la classe MiniObjet
    /// </summary>
    override
    public Transform interaction(GameObject destination)
    {

        layerObjet = transform.gameObject.layer;
        //Ramasser l'objet
        transform.position = destination.transform.position;
        transform.localScale = transform.localScale * tailleRamasse;
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = destination.transform;
        transform.localRotation = new Quaternion(0, 0, 0, 0);
        transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        gameObject.layer = 11;
        return transform;

    }
    /// <summary>
	/// ici, utiliser sert à nettoyer le plancher avec le balai
	/// </summary>
    override
    public void utiliser()
    {
        RaycastHit hit; //Création d'un hit pour le Raycast
        if (Physics.Raycast(transform.position, -transform.forward, out hit, range) && hit.transform.gameObject.layer == 9)
        {
            tuileActive = hit.transform.gameObject;
            nettoyerTuile(tuileActive);
        }

    }

    /// <summary>
	/// sert à netoyer la tuile visée par le balai en lui redonant son material d'origine
	/// </summary>
	/// <param name="tuileActive"></param> tuile visée par le balai
    public void nettoyerTuile(GameObject tuileActive)
    {
        tuileActive.GetComponent<Renderer>().material = matPropre;
        tuileActive.GetComponent<Plancher>().declencherCoroutine();
        tuileActive.GetComponent<Plancher>().setEstSale(false);

    }

}
