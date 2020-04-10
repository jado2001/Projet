using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour{//permet de déclencher un dialogue


    public Dialogue dialogue;

    public void TriggerDialogue(){//pour donner le dialogue au DialogueManager, déclenché en cliquant sur Interagir
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }



}
