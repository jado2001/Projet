using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : Objet
{
    public List<Porte> listePorte;
    override
    public Transform interaction(GameObject destination) {
        foreach (Porte porte in listePorte)
        {
            porte.ouvrir();
        }
        return null;
    }

    override
    public void utiliser() {
    }
}
