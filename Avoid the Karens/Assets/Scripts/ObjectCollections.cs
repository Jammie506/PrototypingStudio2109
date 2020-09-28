using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCollections : MonoBehaviour
{
    public GameObject Shelf;
    
    public Image BreadCross;
    public Image CheeseCross;

    public Interactions interBread;
    public Interactions interCheese;

    public bool droppedBread;
    public bool droppedCheese;

    private void Start()
    {
        BreadCross.gameObject.SetActive(false);
        CheeseCross.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (interBread.gotBread)
        {
            droppedBread = false;
        }
        if (interCheese.gotCheese)
        {
            droppedCheese= false;
        }
    }

    private void OnTriggerStay(Collider shelf)
    {
        if (shelf.gameObject.CompareTag("Player") && interBread.picked && gameObject == Shelf && interBread.gotBread)
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 1;
            interBread.gotBread = false;
            droppedBread = true;
            BreadCross.gameObject.SetActive(true);
            
        } 
        else if (shelf.gameObject.CompareTag("Player") && interCheese.picked && gameObject == Shelf && interCheese.gotCheese)
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 2;
            interCheese.gotCheese = false;
            droppedCheese = true;
            CheeseCross.gameObject.SetActive(true);
        }
    }
}