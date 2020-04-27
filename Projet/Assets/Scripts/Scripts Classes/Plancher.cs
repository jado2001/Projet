using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe des tuiles du plancher du vaisseau
/// </summary>
public class Plancher : MonoBehaviour
{

    public bool estSale = false;///sert à vérifier si la tuile est sale
    public int propreter = 20;///valeur de propreté de la tuile
    public Material matSale;///material à appliquer sur les tuiles quand elles sont sales



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(executeAfterTime(5));
    }

    // Update is called once per frame
    void Update()
    {

        
        //float temps2;
    }

    /// <summary>
	/// sert à changer le material de la tuile pour qu'elle est l'air sale
	/// </summary>
    public void salirTuile()
	{
        GetComponent<Renderer>().material = matSale;
	}

    /// <summary>
	/// sert à exécuter des actions après un certain temps
	/// </summary>
	/// <param name="time"></param> le temps en secondes avant d'exécuter le code
	/// <returns></returns> le temps que doit attendre le IEnumerator
    public IEnumerator executeAfterTime(float time)
	{
        yield return new WaitForSeconds(time);
        salirTuile();
	}

    
}
