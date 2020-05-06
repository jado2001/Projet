using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BebeAlien : Alien
{

    private float dommage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Alien>().verComportement();
    }
}
