using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : Objet
{
    public Porte porte;
    override
    public Transform interaction(GameObject destination) {
        porte.ouvrir();
        return null;
    }

    override
    public void utiliser() {
    }
}
