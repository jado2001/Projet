using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificationMesh : MonoBehaviour
{
    public GameObject swapObject;

    Mesh swapMesh;
    GameObject theTarget;
    // Start is called before the first frame update
    void Start()
    {


            swapMesh = swapObject.GetComponent<MeshFilter>().sharedMesh;
            GetComponent<MeshFilter>().sharedMesh = swapMesh;
        
    }

 
}
