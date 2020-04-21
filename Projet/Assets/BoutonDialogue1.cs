using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonDialogue1 : Objet
{
    public int scene;


    override
    public Transform interaction(GameObject destination)
    {

        SceneManager.LoadScene(scene);
        return null;

    }

    override
    public void utiliser()
    {
    }
}
