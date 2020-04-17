using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couteau : MiniObjet
{
    // Start is called before the first frame update
    
    override
    public void utiliser()
    {
        int layerMaskSansInteraction = 1 << 10 | 1 << 9 | 1 << 11 | 1 << 0;
        layerMaskSansInteraction = ~layerMaskSansInteraction;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMaskSansInteraction))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
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
    }
