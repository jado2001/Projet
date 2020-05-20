using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// classe qui s'occupe de gérer les actions des touches du clavier utilisées dans les mini-jeux des panneaux électriques.
/// </summary>
public class detecterTouches : MonoBehaviour
{
    public GameObject dialogueManager;/// objet qui contient le script DialogueManager qui gère le dialogue
    public GameObject boutonSerie;///bouton pour déclencher le dialogue du circuit en série
    public GameObject boutonParallele;///bouton pour déclencher le dialogue du circuit en parallèle
    public GameObject boutonRC;///bouton pour déclencher le dialogue du circuit RC
    public GameObject boutonPiles;///bouton pour déclencher le dialogue du circuit avec plusieurs piles
    public GameObject choixA;///le bouton du choix A
    public GameObject choixB;///le bouton du choix B
    public GameObject choixC;///le bouton du choix C
    public GameObject boutonContinuer;///le bouton continuer

    /// <summary>
	/// gère la détection de touches du clavier à chaque frame
	/// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UnityEditor.EditorWindow.focusedWindow.maximized = !UnityEditor.EditorWindow.focusedWindow.maximized;
        }
        activerCommandesPrincipales();
        verifierReponse();        
    }

    /// <summary>
	/// déclenche les actions reliés aux boutons d'interaction selon la touche appuyée
	/// </summary>
    public void activerCommandesPrincipales()
	{
        if (Input.GetKeyDown(KeyCode.U))
        {
            boutonSerie.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            boutonParallele.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            boutonRC.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            boutonPiles.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        }
    }

    /// <summary>
	/// vérifie si la touche de la bonne réponse a été appuyée
	/// </summary>
    public void verifierReponse()
	{
        if (Input.GetKeyDown(KeyCode.A))
        {
            choixA.GetComponent<DialogueTrigger>().TriggerQuestion();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            choixB.GetComponent<DialogueTrigger>().TriggerQuestion();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            choixC.GetComponent<DialogueTrigger>().TriggerQuestion();
        }
    }

   

}
