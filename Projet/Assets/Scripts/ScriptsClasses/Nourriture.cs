using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nourriture : MiniObjet
{
    public float vitesseRecuperee, faimRecuperee, vieRecuperee;
    public bool estPreparee;

    override
    public Transform interaction(GameObject destination)
    {
        if (!estPreparee)
        {
            gameObject.tag = "Untagged";
            layerObjet = transform.gameObject.layer;
            //Ramasser l'objet
            transform.position = destination.transform.position;
            transform.localScale = transform.localScale * tailleRamasse;
            transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = destination.transform;
            transform.localRotation = new Quaternion(0, 0, 0, 0);
            gameObject.layer = 11;
            gameObject.tag = "Untagged";
            return transform;
        }
        else
        {
            var listeComponents = destination.GetComponents(typeof(Joueur));
            foreach (Joueur script in listeComponents)
            {
                script.jaugeDeVie += vieRecuperee;
                script.jaugeDeFaim += faimRecuperee;
                script.vitesse += vitesseRecuperee;
            }
            Destroy(this.gameObject);
            return null;
        }

    }

    override
    public void utiliser()
    {
    }

    override
    public void lancer()
    {
         
    }

}
