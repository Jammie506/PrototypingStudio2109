using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollections : MonoBehaviour
{
     public bool picked = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            picked = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            picked = false;
        }
    }

    private void OnTriggerStay(Collider pickup)
    {
        /*if (pickup.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ready to Collect");
        }*/
        if (picked && pickup.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collected");
            
            Destroy(gameObject);
        }
        
    }
}
