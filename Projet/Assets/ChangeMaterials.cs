using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{
    public Material matEau;
    public Material matSavon;
    public float duration;
    private Renderer rend;
    public Lavabo lavabo;
    float lerp;
    bool animation = false, dernierSavon=false;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = matEau;
    }

    // Update is called once per frame
    void Update()
    {
        if (animation)
        {
            lerp += Time.deltaTime / duration;
            if (lavabo.estSavon)
            {
                rend.material.Lerp(matEau, matSavon, lerp);
            }
            else
            {
                rend.material.Lerp(matSavon, matEau, lerp);
            }
            if (lerp>1)
            {
                animation = false;
                lerp = 0;
                dernierSavon = lavabo.estSavon;
            }
        }

        if (lavabo.estSavon != dernierSavon)
        {
            animation = true;
        }



    }
}
