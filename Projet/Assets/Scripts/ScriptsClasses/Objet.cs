using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objet : MonoBehaviour
{
    public float tailleRamasse, layerObjet, durabilitee;
    public abstract Transform interaction(GameObject destination);

    public abstract void utiliser();
}
