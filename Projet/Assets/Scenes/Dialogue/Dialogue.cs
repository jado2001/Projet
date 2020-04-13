using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]//pour que les variables apparaissent dans l'inspecteur

/// <summary>
/// Classe qui sert à définir le dialogue affiché 
/// </summary>
public class Dialogue
{

    /// <summary>
	/// Nom de la personne qui parle dans le dialogue
	/// </summary>
    public string name;

    /// <summary>
	/// Tableau qui contient toutes les phrases du dialogue
	/// </summary>
    [TextArea(3, 10)]//3:minimum de lignes affichées à la fois, 10:max
    public string[] sentences;
}
