using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

/// <summary>
/// classe du bébé extraterrestre qui naît de la saleté du plancher du vaisseau
/// </summary>
public class BebeAlien : Alien
{

    
    private GameObject nourritureCible; ///l'objet que le bébé va chercher pour s'alimenter
    public float faim = 50;/// <summary> la jauge de faim du bébé
    private Vector3 distance; /// <summary> la distance entre un aliment et le bébé

        void Start()
    {
        gameObject.transform.parent = vaisseau.transform.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (chercherNourriture() != null)
        {
            agent.SetDestination(nourritureCible.transform.position);
            verifierDistanceRestante();
            if (faim <= 0)
            {
                transformerBebe();
            }
        } else
        {
            verComportement(1);
        }

        

    }

    /// <summary>
	/// sert à vérifier combien de distance il reste entre le bébé alien et son objectif
	/// </summary>
    public void verifierDistanceRestante()
	{
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    faim = faim - nourritureCible.GetComponent<Nourriture>().faimRecuperee;
                    Destroy(nourritureCible);
                }
            }
        }
    }




    /// <summary>
	/// sert à rechercher des objets dans la scène qui ont le script Nourriture
	/// </summary>
	/// <returns></returns> la nourriture que le bébé va aller chercher
    public GameObject chercherNourriture()
    {
        float distanceMin = 1000;
        
        

        foreach (GameObject objet in GetAllObjectsOnlyInScene())
        {
            var script = objet.GetComponent<Nourriture>();
            if (script != null)
            {
                distance = objet.transform.position - transform.position;
				if (distance.magnitude <= distanceMin)
				{
                    distanceMin = distance.magnitude;
                    nourritureCible = objet;
				}                
            }
        }

        return nourritureCible;
    }

    /// <summary>
	/// sert à transformer le bébé alien en bébé adulte en changeant son scale
	/// </summary>
    public void transformerBebe()
	{
        transform.localScale = new Vector3(1, 1, 1);
        Alien scriptAlien = gameObject.AddComponent(typeof(Alien)) as Alien;
        scriptAlien.joueur = joueur;
        scriptAlien.agent = agent;
        Destroy(this);
	}

    /// <summary>
	/// sert à faire une liste de tous les objets dans la scène
	/// </summary>
	/// <returns></returns> liste de tous les objets dans la scène
    public List<GameObject> GetAllObjectsOnlyInScene()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }

}
