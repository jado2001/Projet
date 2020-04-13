using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sert à gérer l'affichage du dialogue des panneaux électriques
/// </summary>
public class DialogueManager : MonoBehaviour
{//gérer l'affichage des dialogues

    public Text nameText;/// nom de la personne qui parle
    public Text dialogueText;/// texte du dialogue
    public GameObject Choix1;/// Premier bouton qu'on peut utiliser pour donner une réponse
    public GameObject Choix2;/// Deuxième bouton qu'on peut utiliser pour donner une réponse
    public GameObject Choix3;/// Troisième bouton qu'on peut utiliser pour donner une réponse
    public string nomPanneau;/// nom du panneau avec lequel on interagit
    public int compteur = 0; /// compteur qui sert à gérer l'affichage des boutons de choix de réponses

    public Animator animator;//s'occupe des animations pour la boîte de dialogue

    private Queue<string> sentences;//File (FIFO) qui contient les phrases du dialogue

    /// <summary>
	/// Sert à créer la file de phrases lorsque le script est appelé
	/// </summary>
    void Start()
    {
        sentences = new Queue<string>();
    }

    /// <summary>
    /// Fait commencer le dialogue
    /// </summary>
    /// <param name="dialogue"></param> dialogue associé au panneau avec lequel on interagit
    public void StartDialogue(Dialogue dialogue)
    {
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

    /// <summary>
	/// Sert à vérifier les réponses du joueur aux questions à partir des noms du panneau et du bouton de réponse
	/// </summary>
	/// <param name="dialogue"></param>dialogue associé au panneau avec lequel on interagit 
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
        else if ((dialogue.name).Equals("A") && nomPanneau.Equals("Panneau électrique 3"))
        {
            sentences.Enqueue("Bonne réponse !");
        }
        else if ((dialogue.name).Equals("B") && nomPanneau.Equals("Panneau électrique 4"))
        {
            sentences.Enqueue("Bonne réponse !");
        }
        else
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


    /// <summary>
	/// Gère l'affichage des phrases
	/// </summary>
    public void DisplayNextSentence()
    {//enclenché en cliquant sur Continuer

        if (sentences.Count == 1 && compteur == 0)
        {
            Choix1.SetActive(true);
            Choix2.SetActive(true);
            Choix3.SetActive(true);

        }
        else if (sentences.Count == 0)
        {
            EndDialogue();
            compteur = 0;
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();//arrête TypeSentence si le joueur clique sur continuer avant que l'animation soit terminée
        StartCoroutine(TypeSentence(sentence));
    }

    /// <summary>
	/// Méthode qui fait afficher les phrases une lettre à la fois
	/// </summary>
	/// <param name="sentence"></param> la phrase à afficher
	/// <returns></returns> le temps que doit attendre le IEnumerator pour afficher la prochaine lettre
    IEnumerator TypeSentence(string sentence)
    {//Coroutine
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())//.ToCharArray convertit la phrase en un array de char
        {
            dialogueText.text += letter;//on ajoute la lettre à la phrase
            yield return null;//attendre 1 frame avant d'ajouter la prochaine lettre
        }
    }

    /// <summary>
	/// Sert à faire disparaître la boîte de dialogue quand le dialogue est terminé
	/// </summary>
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
