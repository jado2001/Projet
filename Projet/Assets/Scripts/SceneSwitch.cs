using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// classe qui sert à changer de scène
/// </summary>
public class SceneSwitch : MonoBehaviour
{
    /// <summary>
	/// sert à charger la première scène
	/// </summary>
	/// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
	/// sert à charger la scàne principale (celle du vaisseau)
	/// </summary>
    public void OnTriggerReturn()
    {
        SceneManager.LoadScene(0);
    }
}
