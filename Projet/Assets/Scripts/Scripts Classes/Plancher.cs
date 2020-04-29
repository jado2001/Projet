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
        declencherCoroutine();
    }

    /// <summary>
	/// sert à changer le material de la tuile pour qu'elle est l'air sale
	/// </summary>
    public void changerMat()
	{
        GetComponent<Renderer>().material = matSale;
	}

    /// <summary>
	/// sert à déclencher la coroutine qui rend les tuiles sales
	/// </summary>
    public void declencherCoroutine()
	{
        StartCoroutine(salirTuile(5));
        
    }

    /// <summary>
	/// sert à salir la tuile après un certain temps
	/// </summary>
	/// <param name="time"></param> le temps en secondes avant d'exécuter le code
	/// <returns></returns> le temps que doit attendre le IEnumerator
    public IEnumerator salirTuile(float time)
	{
        yield return new WaitForSeconds(time);
        changerMat();
    }

    /// <summary>
	/// sert à faire apparaître un alien après un certain temps
	/// </summary>
	/// <param name="time"></param> le temps en secondes avant d'exécuter le code
	/// <returns></returns> le temps que doit attendre le IEnumerator
    public IEnumerator apparaitreAlien(float time)
    {
        yield return new WaitForSeconds(time);
        spawnAlien();
    }

    public void spawnAlien()
	{

	}
}
