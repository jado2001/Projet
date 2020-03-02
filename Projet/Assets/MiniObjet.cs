using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniObjet: Objet
{

    override
    public void interaction(GameObject destination)
    {
        //Ramasser l'objet
        transform.position = destination.transform.position;
        transform.localRotation = destination.transform.localRotation;
        transform.localScale = transform.localScale*tailleRamasse; 
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = destination.transform;
        //gameObject.layer = 11;
        Debug.Log("boogieman");
    }
    override
    public void utiliser()
    {

    }
}
