using System.Collections;
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
<<<<<<< HEAD

       
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

            
            

=======
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
>>>>>>> parent of 9c4abd0... progression alienmouvement
        }
        
    }
}
