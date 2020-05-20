using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// sert à gérer la scène du Game Over
/// </summary>
public class Mort : MonoBehaviour
{
    /// <summary>
	/// détecter les touches pour gérer le choix du joueur
	/// </summary>
    void Update()
	{
        if (Input.GetKeyDown(KeyCode.Q))
        {
            quitter();
        }
        else if (Input.GetKeyDown(KeyCode.R))
		{
            recommencer();
		}
    }

    /// <summary>
	/// pour quitter le jeu
	/// </summary>
	public void quitter()
	{
        UnityEditor.EditorApplication.isPlaying = false;
    }

    /// <summary>
	/// pour revenir au jeu quand on veut continuer à jouer
	/// </summary>
	public void recommencer()
	{
        SceneManager.LoadScene(0);
    }

}
