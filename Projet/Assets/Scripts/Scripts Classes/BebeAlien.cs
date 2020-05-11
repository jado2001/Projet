using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BebeAlien : Alien
{
   
    private Queue<GameObject> nourriture = new Queue<GameObject>(); /// la liste d'objets avec le script nourriture dans la scène
    private GameObject nourritureCible; ///l'objet que le bébé va chercher pour s'alimenter



    // Update is called once per frame
    void FixedUpdate()
    {

        GetComponent<Alien>().verComportement(1);

		if (chercherNourriture())
		{
            nourritureCible = nourriture.Dequeue();
		}
    }

    /// <summary>
	/// sert à rechercher des objets dans la scène qui ont le script Nourriture
	/// </summary>
	/// <returns></returns> si c'est true, il y a de la nourriture dans la scène, si false, il y en a plus
    public bool chercherNourriture()
    {

        foreach (GameObject objet in GetAllObjectsOnlyInScene())
        {
            var script = objet.GetComponent<Nourriture>();
            if (script != null)
            {
                nourriture.Enqueue(objet);
            }
        }

        if (nourriture.Count != 0)
		{
            return true;
        }

        return false;
    }

    /// <summary>
	/// sert à transformer le bébé alien en bébé adulte en changeant son scale
	/// </summary>
    public void transformerBebe()
	{
        transform.localScale = new Vector3(1, 1, 1);
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
