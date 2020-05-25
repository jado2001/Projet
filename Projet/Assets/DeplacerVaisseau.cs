using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacerVaisseau : MonoBehaviour
{
    public Transform objetASuivre;
    private Vector3 vecteurDifference;
    // Start is called before the first frame update
    void Start()
    {
        vecteurDifference = objetASuivre.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = objetASuivre.position -vecteurDifference;
        transform.rotation = objetASuivre.rotation;
    }
}
