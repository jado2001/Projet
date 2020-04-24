using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
	{
        SceneManager.LoadScene(1);
	}

    public void OnTriggerReturn()
    {
        SceneManager.LoadScene(0);
    }

}
