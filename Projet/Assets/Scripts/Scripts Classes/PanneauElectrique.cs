using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanneauElectrique : Objet
{

    /// <summary>
    /// Dialogue associé au panneau avec lequel on interagit, voir Dialogue.cs pour infos sur la classe
    /// </summary>
    public Dialogue dialogue;

    override
    public Transform interaction(GameObject destination)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        return null;

    }

    override
    public void utiliser()
    {

        
    }


}
