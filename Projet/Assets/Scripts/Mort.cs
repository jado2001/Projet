using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mort : MonoBehaviour
{
    public void quitter()
	{
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void recommencer()
	{
        SceneManager.LoadScene(0);
    }

}
