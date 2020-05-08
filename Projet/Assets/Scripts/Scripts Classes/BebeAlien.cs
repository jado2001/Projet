using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BebeAlien : Alien
{
   
    private Queue<GameObject> nourriture = new Queue<GameObject>();
    private GameObject nourritureCible;
    


    // Update is called once per frame
    void FixedUpdate()
    {

        GetComponent<Alien>().verComportement(1);

		if (chercherNourriture())
		{
            nourritureCible = nourriture.Dequeue();
		}
    }

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

    public void transformerBebe()
	{
        transform.localScale = new Vector3(1, 1, 1);
	}

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
