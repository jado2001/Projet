﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvementAlien : MonoBehaviour
{
    public Camera cam;

    public Transform joueur;

    public NavMeshAgent agent;

    public float rotation;

    // Update is called once per frame
    void Update()
    {

       
        Debug.DrawRay(transform.position, transform.forward*100, Color.green);
        RaycastHit hit;
        Vector3 vecteurDirection = joueur.position - transform.position;
        if (Physics.Raycast(transform.position, vecteurDirection / vecteurDirection.magnitude, out hit) && hit.transform.gameObject.layer == joueur.gameObject.layer)
        {
            agent.SetDestination(joueur.position);

            //float angle = Vector3.Angle(vecteurDirection, transform.forward);

            rotation = transform.rotation.y;
            Debug.Log(rotation);

        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit) && hit.transform.gameObject.layer == 12)
        {

            Debug.Log(hit.transform.name);
            agent.SetDestination(hit.point);
            rotation = transform.rotation.y;
            Debug.Log(rotation);
        }
        else if (agent.velocity.magnitude == 0)
        {
            
            rotation = rotation + .5f;
            transform.localRotation = Quaternion.Euler(0f, rotation, 0f);

            
            

        }
        
    }
}
