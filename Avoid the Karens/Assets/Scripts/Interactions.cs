﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    public ObjectCollections objectBread;
    public ObjectCollections objectCheese;
    
    public GameObject Bread;
    public GameObject Cheese;
    public Image BreadCross;
    public Image CheeseCross;

    public bool picked;
    public bool gotBread = false;
    public bool gotCheese = false;

    private void Start()
    {
        
        BreadCross.gameObject.SetActive(false);
        CheeseCross.gameObject.SetActive(false);
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
    }

    public void OnTriggerStay(Collider pickup)
    {
        if (objectBread.breadPlease)
        {
            Debug.Log("Transferred");
            
            if (picked)
            {
                Score.CoinAmount += 1;
                gotBread = true;
                BreadCross.gameObject.SetActive(true);
                //Destroy(gameObject);
            }
        }
        if (objectCheese.cheesePlease)
        {
            Debug.Log("Transferred");
            
            if (picked)
            {
                Score.CoinAmount += 2;
                gotCheese = true;
                CheeseCross.gameObject.SetActive(true);
                //Destroy(gameObject);
            }
        }
    }

    /*public void OnTriggerEnter(Collider drops)
    {
        if (gameObject == Bread && picked && gameObject.CompareTag("Player"))
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 1;
            gotBread = false;
            BreadCross.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }*/
}
