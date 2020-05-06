﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Porte : Objet
{
    public float movementSpeed = -10f, distanceAParcourir=3f;
    public float distanceTravelled = 0;
    public Vector3 lastPosition;
    public Vector3 startPos;
    public bool ouvert, estEnMouvement;
<<<<<<< HEAD
    public GameObject porteDetruite;
=======
>>>>>>> master

    override
      public Transform interaction(GameObject destination)
    {
        return null;
    }
    void Start()
    {
        durabilitee=10;
        lastPosition = transform.position;
        durabilitee = 10;
    }

    override
    public void utiliser()
    {
    }
    void Update()
    {
        if (durabilitee <= 0)
        {
            
            remplacerPorte();
        }
        if (estEnMouvement)
        {
            mouvement();
            if (distanceTravelled >= distanceAParcourir)
            {
                distanceTravelled = 0;
                estEnMouvement = false;
            }
        }
    }

    public void ouvrir()
    {
        if (!estEnMouvement)
        {
            movementSpeed = -movementSpeed;
            estEnMouvement = true;
        }
    }

    void mouvement()
    {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
    }

    void remplacerPorte()
    {
        
       GameObject PorteDetruite = Instantiate(porteDetruite, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }

}
