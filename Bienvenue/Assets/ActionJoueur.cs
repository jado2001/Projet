using UnityEngine;

public class ActionJoueur : MonoBehaviour
{
    public float range;
    public Camera camera;
    public Transform objetTenu=null;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Interagir();
        } else if (Input.GetButtonDown("Fire2"))
        {
            Lancer();
        }
    }

    void Interagir()
    {
        int layerMaskJoueur=1<<10 | 1<<12;
        layerMaskJoueur = ~layerMaskJoueur;
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range, layerMaskJoueur ) )
        {
            Debug.Log(hit.transform.name);
            objetTenu = hit.transform;
            objetTenu.localScale += new Vector3(-0.5f, -0.5f, -0.5f);
            objetTenu.position = camera.transform.position + camera.transform.forward + new Vector3(-0.5f, -0.5f, 0);
            objetTenu.rotation = camera.transform.rotation;
            objetTenu.gameObject.layer = 11;
            objetTenu.parent = camera.transform;
            objetTenu = hit.transform;
        }
    }

    void Lancer()
    {
        objetTenu.parent = null;
    }   
}
