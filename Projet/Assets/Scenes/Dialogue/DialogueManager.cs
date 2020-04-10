using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {//gérer l'affichage des dialogues

    public Text nameText;
    public Text dialogueText;
    public GameObject Choix1;
    public GameObject Choix2;
    public GameObject Choix3;
    public string nomPanneau;
    public int compteur=0;

    public Animator animator;//s'occupe des animations pour la boîte de dialogue

    private Queue<string> sentences;//FIFO, contient les phrases du dialogue

    
    void Start()
    {
        sentences = new Queue<string>();
    }

  
    public void StartDialogue(Dialogue dialogue){
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        nomPanneau = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);//on ajoute les phrases à la liste
        }

        DisplayNextSentence();

    }

    public void StartReaction(Dialogue dialogue)
	{
        if ((dialogue.name).Equals("C") && nomPanneau.Equals("Panneau électrique 1"))
        {
            sentences.Enqueue("Bonne réponse !");
        }
        else if ((dialogue.name).Equals("B") && nomPanneau.Equals("Panneau électrique 2"))
        {
            sentences.Enqueue("Bonne réponse !");
        }
        else if((dialogue.name).Equals("A") && nomPanneau.Equals("Panneau électrique 3"))
        {
            sentences.Enqueue("Bonne réponse !");
        }
        else if((dialogue.name).Equals("B") && nomPanneau.Equals("Panneau électrique 4"))
        {
            sentences.Enqueue("Bonne réponse !");
        } else
		{
            sentences.Enqueue("Mauvaise réponse !");
        }
        sentences.Enqueue("C'est tout pour ce panneau! Si vous voulez continuez à apprendre de nouvelles choses sur les circuits électriques, continuez à explorer pour trouver les autres panneaux !");
        Choix1.SetActive(false);
        Choix2.SetActive(false);
        Choix3.SetActive(false);
        compteur++;
        DisplayNextSentence();
    }

    

    public void DisplayNextSentence(){//enclenché en cliquant sur Continuer
        
		if (sentences.Count == 1 && compteur==0)
		{
            Choix1.SetActive(true);
            Choix2.SetActive(true);
            Choix3.SetActive(true);
            
        }
        else if (sentences.Count == 0){
            EndDialogue();
            compteur = 0;
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();//arrête TypeSentence si le joueur clique sur continuer avant que l'animation soit terminée
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence){//Coroutine
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())//.ToCharArray convertit la phrase en un array de char
        {
            dialogueText.text += letter;//on ajoute la lettre à la phrase
            yield return null;//attendre 1 frame avant d'ajouter la prochaine lettre
        }
    }

    void EndDialogue(){
        animator.SetBool("IsOpen", false);
    }
}
