using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffichageChoix : MonoBehaviour
{
    public GameObject Choix1;
    public GameObject Choix2;
    public GameObject Choix3;

   
    public void afficherChoix1()
	{
        Choix1.GetComponentInChildren<Text>().text = "A";
	}

    public void afficherChoix2()
    {
        Choix2.GetComponentInChildren<Text>().text = "B";
    }

    public void afficherChoix3()
    {
        Choix3.GetComponentInChildren<Text>().text = "C";
    }


    // Update is called once per frame
    //void Update()
    //{
    //Choix1.SetActive(false);
    //  Choix2.SetActive(false);
    //  Choix3.SetActive(false);
    //}
}
