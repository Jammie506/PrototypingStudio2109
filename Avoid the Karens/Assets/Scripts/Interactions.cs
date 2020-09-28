using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    public GameObject bread;
    public GameObject cheese;
    
     public ObjectCollections shelf;
    
    public Renderer bRend;
    public Renderer cRend;
    
    public Image breadHigh;
    public Image cheeseHigh;
    public Text pickupControls;

    public bool picked;
    public bool gotBread;
    public bool gotCheese;
    public bool on;

    private void Start()
    {
        breadHigh.gameObject.SetActive(false);
        cheeseHigh.gameObject.SetActive(false);
        pickupControls.gameObject.SetActive(false);

        gotBread = false;
        gotCheese = false;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            picked = true;
            Debug.Log("Pressed");
            
        }
        else
        {
            picked = false;
        }

        if (shelf.droppedBread && gameObject == bread)
        {
            breadHigh.gameObject.SetActive(false);
        }
        else if (shelf.droppedCheese && gameObject == cheese)
        {
            cheeseHigh.gameObject.SetActive(false);
        }
    }
    
    //this is where items are collected, they are dropped in ObjectCollections
    public void OnTriggerStay(Collider enter)
    {
        if (enter.gameObject.CompareTag("Player"))
        { 
            on = true; 
            pickupControls.gameObject.SetActive(true);
        }
        
        if (enter.gameObject.CompareTag("Player") && picked && gameObject == bread && !gotBread)
        {
            Debug.Log("Transferred");
                gotBread = true;
                bRend.enabled = false;
                breadHigh.gameObject.SetActive(true);
        }
        else if (enter.gameObject.CompareTag("Player") && picked && gameObject == cheese && !gotCheese)
        {
            Debug.Log("Transferred");
                gotCheese = true;
                cRend.enabled = false;
                cheeseHigh.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            on = false; 
            pickupControls.gameObject.SetActive(false);
        }
        
    }
}
