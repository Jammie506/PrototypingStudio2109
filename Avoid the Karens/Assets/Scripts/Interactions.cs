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
    public GameObject milk;
    public GameObject water;
    public GameObject coke;
    public GameObject veg;
    public GameObject meat;
    
     public ObjectCollections shelf;
    
    public Renderer bRend;
    public Renderer cRend;
    public Renderer mRend;
    public Renderer wRend;
    public Renderer ccRend;
    public Renderer vRend;
    public Renderer meRend;
    
    public Image breadHigh;
    public Image cheeseHigh;
    public Image milkHigh;
    public Image waterHigh;
    public Image cokeHigh;
    public Image vegHigh;
    public Image meatHigh;
    public Text pickupControls;

    public bool picked;
    public bool gotBread;
    public bool gotCheese;
    public bool gotMilk;
    public bool gotWater;
    public bool gotCoke;
    public bool gotVeg;
    public bool gotMeat;
    public bool on;

    private void Start()
    {
        breadHigh.gameObject.SetActive(false);
        cheeseHigh.gameObject.SetActive(false);
        milkHigh.gameObject.SetActive(false);
        waterHigh.gameObject.SetActive(false);
        cokeHigh.gameObject.SetActive(false);
        vegHigh.gameObject.SetActive(false);
        meatHigh.gameObject.SetActive(false);
        pickupControls.gameObject.SetActive(false);

        gotBread = false;
        gotCheese = false;
        gotMilk = false;
        gotWater = false;
        gotCoke = false;
        gotVeg = false;
        gotMeat = false;
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
        else if (shelf.droppedMilk && gameObject == milk)
        {
            milkHigh.gameObject.SetActive(false);
        }
        else if (shelf.droppedWater && gameObject == water)
        {
            waterHigh.gameObject.SetActive(false);
        }
        else if (shelf.droppedCoke && gameObject == coke)
        {
            cokeHigh.gameObject.SetActive(false);
        }
        else if (shelf.droppedVeg && gameObject == veg)
        {
            vegHigh.gameObject.SetActive(false);
        }
        else if (shelf.droppedMeat && gameObject == meat)
        {
            meatHigh.gameObject.SetActive(false);
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
        else if (enter.gameObject.CompareTag("Player") && picked && gameObject == milk && !gotMilk)
        {
            Debug.Log("Transferred");
            gotMilk = true;
            mRend.enabled = false;
            milkHigh.gameObject.SetActive(true);
        }
        else if (enter.gameObject.CompareTag("Player") && picked && gameObject == water && !gotWater)
        {
            Debug.Log("Transferred");
            gotWater = true;
            wRend.enabled = false;
            waterHigh.gameObject.SetActive(true);
        }
        else if (enter.gameObject.CompareTag("Player") && picked && gameObject == coke && !gotCoke)
        {
            Debug.Log("Transferred");
            gotCoke = true;
            ccRend.enabled = false;
            cokeHigh.gameObject.SetActive(true);
        }
        else if (enter.gameObject.CompareTag("Player") && picked && gameObject == veg && !gotVeg)
        {
            Debug.Log("Transferred");
            gotVeg = true;
            vRend.enabled = false;
            vegHigh.gameObject.SetActive(true);
        }
        else if (enter.gameObject.CompareTag("Player") && picked && gameObject == meat && !gotMeat)
        {
            Debug.Log("Transferred");
            gotMeat = true;
            meRend.enabled = false;
            meatHigh.gameObject.SetActive(true);
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
