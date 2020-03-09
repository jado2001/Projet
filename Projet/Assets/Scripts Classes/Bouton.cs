using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : Objet
{
    override
    public Transform interaction(GameObject destination) {
        return transform;
    }

    override
    public void utiliser() {
    }
}
