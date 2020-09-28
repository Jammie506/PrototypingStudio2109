using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    public GameObject Bread;
    public GameObject Cheese;
    
    public ObjectCollections Shelf;
    
    public Renderer bRend;
    public Renderer cRend;
    
    public Image breadHigh;
    public Image cheeseHigh;

    public bool picked;
    public bool gotBread;
    public bool gotCheese;

    private void Start()
    {
        breadHigh.gameObject.SetActive(false);
        cheeseHigh.gameObject.SetActive(false);

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

        if (Shelf.droppedBread && gameObject == Bread)
        {
            breadHigh.gameObject.SetActive(false);
        }
        else if (Shelf.droppedCheese && gameObject == Cheese)
        {
            cheeseHigh.gameObject.SetActive(false);
        }
    }
    
    //this is where items are collected, they are dropped in ObjectCollections
    public void OnTriggerStay(Collider enter)
    {
        if (enter.gameObject.CompareTag("Player") && picked && gameObject == Bread && !gotBread)
        {
            Debug.Log("Transferred");
                gotBread = true;
                bRend.enabled = false;
                breadHigh.gameObject.SetActive(true);
        }
        else if (enter.gameObject.CompareTag("Player") && picked && gameObject == Cheese && !gotCheese)
        {
            Debug.Log("Transferred");
                gotCheese = true;
                cRend.enabled = false;
                cheeseHigh.gameObject.SetActive(true);
        } 
    }
}
