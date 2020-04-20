using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : Objet

{
    override
    public Transform interaction(GameObject destination)
    {
        Debug.Log("Touché");
        return null;
    }

    override
    public void utiliser()
    {


    }
}
