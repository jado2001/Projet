using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MiniObjet: Objet
{
    public bool estCoupe;
    public float cuisson;
    public bool estEnFeu;
    public bool estEntrainDeCuire;

    void Update()
    {
        if (cuisson>=60) //Faire que l'objet brûle
        {
            estEnFeu = true;
        }
        if (estEnFeu) //Faire que l'objet refroidit petit à petit
        {
            cuisson -= Time.deltaTime;
        }
        if (cuisson<=50) //Éteindre le feu
        {
            estEnFeu = false;
        }
    }

    override
    public Transform interaction(GameObject destination)
    {
        gameObject.tag = "Untagged";
        estEntrainDeCuire = false;
        layerObjet = transform.gameObject.layer;
        //Ramasser l'objet
        transform.position = destination.transform.position;
        transform.localScale = transform.localScale*tailleRamasse; 
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = destination.transform;
        transform.localRotation = new Quaternion(0,0,0,0);
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
