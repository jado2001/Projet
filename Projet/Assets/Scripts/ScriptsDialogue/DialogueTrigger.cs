using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe qu'on met sur certains élments du jeu pour qu'ils déclenchent un dialogue
/// </summary>
public class DialogueTrigger : Objet{//permet de déclencher un dialogue

    /// <summary>
	/// Dialogue associé au panneau avec lequel on interagit, voir Dialogue.cs pour infos sur la classe
	/// </summary>
    public Dialogue dialogue;


    override
    public Transform interaction(GameObject destination)
    {
        TriggerDialogue();
        return null;
    }

    override
    public void utiliser()
    {
    }

    

    /// <summary>
	/// Méthode qui sert à appeler le DialogueManager pour commencer le dialogue
	/// </summary>
    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    /// <summary>
	/// /// Méthode qui sert à appeler le DialogueManager pour commencer le dialogue associé aux questions posées à la fin de chaque interaction avec un panneau
	/// </summary>
    public void TriggerQuestion()
	{
        FindObjectOfType<DialogueManager>().StartReaction(dialogue);
    }

}
