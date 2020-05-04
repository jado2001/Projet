using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// classe attachée à l'objet du vaisseau qui permet de déclencher le mini-jeu des panneaux électriques dans une autre scène
/// </summary>
public class BoutonDialogue1 : Objet
{
    public int scene;///numéro de la scène qu'on veut faire afficher

    /// <summary>
    /// méthode qui load la scène correspondant au bon panneau électrique (cela dépend de la salle du vaisseau dans laquelle le joueur se trouve)
    /// </summary>
    override
    public Transform interaction(GameObject destination)
    {
        SceneManager.LoadScene(scene);
        return null;

    }

    /// <summary>
    /// méthode héritée de la classe Objet (inutilisée ici)
    /// </summary>
    override
    public void utiliser()
    {
    }
}
