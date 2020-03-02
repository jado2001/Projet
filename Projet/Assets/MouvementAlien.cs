using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvementAlien : MonoBehaviour
{
    public Camera cam;

    public Transform joueur;

    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        /**if (Input.GetButtonDown("Fire1")) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            

            if (Physics.Raycast(ray, out hit))
            {
                //Move alien
                agent.SetDestination(hit.point);
            }
        }
    **/
        RaycastHit hit;
        Vector3 vecteurDirection = joueur.position - transform.position;
        if (Physics.Raycast(transform.position,vecteurDirection/vecteurDirection.magnitude,out hit) && hit.transform.gameObject.layer == joueur.gameObject.layer)
        {
            agent.SetDestination(joueur.position);
            Debug.Log(hit.transform.name);
        }
        
    }
}
