using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]//pour que les variables apparaissent dans l'inspecteur

public class Dialogue {//dialogue qu'on donne à DialogueManager
    public string name;

    [TextArea(3, 10)]//3:minimum de lignes affichées à la fois, 10:max
    public string[] sentences;
}
