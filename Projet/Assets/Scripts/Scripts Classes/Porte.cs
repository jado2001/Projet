using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : Objet
{
    public float movementSpeed = 10;
    public float distanceTravelled = 0;
    public Vector3 lastPosition;
    public Vector3 startPos;
    public bool ouvert;
    override
      public Transform interaction(GameObject destination)
    {
        return null;
    }
    void Start()
    {
        lastPosition = transform.position;
    }

    override
    public void utiliser()
    {
    }

    public void ouvrir()
    {
        Debug.Log("allo");
        startPos = transform.position;
        if (ouvert)
        {


            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            distanceTravelled += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;



            if (distanceTravelled >= 10)
            {

                ouvert = false;
                distanceTravelled = 0;
            }

        }
        else
        {

            transform.Translate(-Vector3.right * movementSpeed * Time.deltaTime);
            Debug.Log("allo");
            distanceTravelled += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;


            if (distanceTravelled >= 10)
            {
                ouvert = true;
                distanceTravelled = 0;
            }
        }
    }
}
