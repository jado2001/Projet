using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objet : MonoBehaviour
{
    public float tailleRamasse;
    public abstract void interaction(GameObject destination);

    public abstract void utiliser();
}
