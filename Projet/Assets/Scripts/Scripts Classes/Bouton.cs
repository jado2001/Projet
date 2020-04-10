using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : Objet
{
    public List<Porte> portes = new List<Porte>();
    override
    public Transform interaction(GameObject destination) {
        foreach (Porte porte in portes) { 
            porte.ouvrir();
    }
        return null;
    }

    override
    public void utiliser() {
    }
}
