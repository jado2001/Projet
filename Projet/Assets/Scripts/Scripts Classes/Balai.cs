using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balai : MiniObjet
{
    

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

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
