using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniObjet: Objet
{

    public bool estCoupe;
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
        gameObject.layer = 11;
        return transform;
    }
    override
    public void utiliser()
    {

    }

    public virtual void lancer()
    {

    }
}
