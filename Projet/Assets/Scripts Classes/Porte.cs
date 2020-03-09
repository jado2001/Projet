using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : Objet
{
    public bool ouvert;
    override
      public Transform interaction(GameObject destination)
    {
        return transform;
    }

    override
    public void utiliser()
    {
    }

    public void ouvrir()
    {

    }
}
