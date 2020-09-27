using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollections : MonoBehaviour
{
    public GameObject Bread;
    public GameObject Cheese;
    
    public Interactions interactions;
    
    public bool breadPlease = false;
    public bool cheesePlease = false;

    private void Update()
    {
        /*if (interactions.gotBread)
        {
            Destroy(gameObject);
        }
        
        if (interactions.gotCheese)
        {
            Destroy(gameObject);
        }*/
    }

    private void OnTriggerEnter(Collider enter)
    {
        if (gameObject == Bread && enter.gameObject.CompareTag("Player") && !breadPlease)
        {
            Debug.Log("Entered Bread");
            breadPlease = true;
            //Destroy(gameObject);
        } 
        else if (gameObject == Cheese && enter.gameObject.CompareTag("Player") && !cheesePlease)
        {
            Debug.Log("Entered Cheese");
            cheesePlease = true;
            //Destroy(gameObject);
        }
    }

    /*private void OnTriggerExit(Collider exit)
    {
        if (gameObject == Bread && exit.gameObject.CompareTag("Player") && breadPlease)
        {
            Debug.Log("Exited Bread");
            breadPlease = false;
        }
        else if (gameObject == Cheese && exit.gameObject.CompareTag("Player") && cheesePlease)
        {
            Debug.Log("Exited Cheese");
            cheesePlease = false;
        }
    }*/
}