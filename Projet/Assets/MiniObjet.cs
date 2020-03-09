using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniObjet: Objet
{

    override
    public Transform interaction(GameObject destination)
    {
        layerObjet = transform.gameObject.layer;
        //Ramasser l'objet
        transform.position = destination.transform.position;
        transform.localRotation = destination.transform.localRotation;
        //transform.localScale = transform.localScale*tailleRamasse; 
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = destination.transform;
        gameObject.layer = 11;
        return transform;
    }
    override
    public void utiliser()
    {

    }
}
