using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detecterTouches : MonoBehaviour
{
    public GameObject dialogueManager;
    public GameObject boutonSerie;
    public GameObject boutonParallele;
    public GameObject boutonRC;
    public GameObject boutonPiles;
    public GameObject choixA;
    public GameObject choixB;
    public GameObject choixC;
    public GameObject boutonContinuer;

    void Update()
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
        verifierReponse();        
    }

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
