using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvementAlien : MonoBehaviour
{
    public Camera cam;

    public Transform joueur;

    public NavMeshAgent agent;

    private float rotation;

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        Vector3 vecteurDirection = joueur.position - transform.position;
        if (Physics.Raycast(transform.position,vecteurDirection/vecteurDirection.magnitude,out hit) && hit.transform.gameObject.layer == joueur.gameObject.layer)
        {
            agent.SetDestination(joueur.position);
            
            float angle = Vector3.Angle(vecteurDirection, transform.forward);

            transform.localRotation = Quaternion.Euler(0f, angle ,0f);
            Debug.Log(hit.transform.name);

        } else
        {
            rotation = rotation + .5f;
            int layerMask = 1 << 12;
            layerMask = ~layerMask;
            transform.localRotation = Quaternion.Euler(0f, rotation, 0f);
            if (Physics.Raycast(transform.position, new Vector3(0f, rotation, 0f),out hit, layerMask) )
            {
                agent.SetDestination(hit.point);
            }
            
        }
        
    }
}
