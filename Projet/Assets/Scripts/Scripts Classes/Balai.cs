using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balai : MiniObjet
{
    public GameObject tuileActive;

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

    override
    public void utiliser()
    {
        RaycastHit hit; //Création d'un hit pour le Raycast
        if (Physics.Raycast(transform.position, transform.forward, out hit) && hit.transform.gameObject.layer == 9)
        {
            tuileActive = hit.transform.gameObject;
            tuileActive.GetComponent<Plancher>().nettoyerTuile();
        }

    }

   
}
