using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enter : MonoBehaviour
{
    private bool inVehicle = false;
    Ship vehicleScript;
    ShipInput inputScript;
    ShipPhysics physicsScript;
    public GameObject guiObj;
    public GameObject guiExit;
    GameObject player;
    public Camera camera;
    public GameObject hud;


    void Start()
    {
        vehicleScript = GetComponent<Ship>();
        inputScript = GetComponent<ShipInput>();
        physicsScript = GetComponent<ShipPhysics>();
        player = GameObject.FindWithTag("Player");
       
        if (hud != null)
        {
            Debug.Log("on est in");
        }
        if (hud == null){
            Debug.Log("on est out");
        }

        guiObj.SetActive(false);
        guiExit.SetActive(false);
       // UnityEditor.EditorWindow.focusedWindow.maximized = !UnityEditor.EditorWindow.focusedWindow.maximized;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            guiObj.SetActive(true);
            if (Input.GetKey(KeyCode.P))
            {
                Debug.Log(" ca fonctionne p");

                guiObj.SetActive(false);
                player.transform.parent = gameObject.transform;
                vehicleScript.enabled = true;
                inputScript.enabled = true;
                physicsScript.enabled = true;
                player.SetActive(false);
                hud.SetActive(true);
                camera.enabled = true;
                inVehicle = true;
                guiExit.SetActive(true);

                
            }
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("3");
            guiObj.SetActive(false);
            guiExit.SetActive(false);
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.G))
        {
            Debug.Log("4");
            vehicleScript.enabled = false;
            inputScript.enabled = false;
            physicsScript.enabled = false;
            player.SetActive(true);
            hud.SetActive(false);
            player.transform.parent = null;
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            inVehicle = false;
            guiExit.SetActive(false);

        }
        Cursor.lockState = CursorLockMode.Confined;
        Screen.lockCursor = true;
        Cursor.visible = false;
       
        

    }
}
