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

    private void OnTriggerStay(Collider shelf)
    {
        if (shelf.gameObject.CompareTag("Player") && interBread.picked && gameObject == Shelf && interBread.gotBread)
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 1;
            interBread.gotBread = false;
            BreadCross.gameObject.SetActive(true);
            //Destroy(gameObject);
        } 
        else if (shelf.gameObject.CompareTag("Player") && interCheese.picked && gameObject == Shelf && interCheese.gotCheese)
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 2;
            interCheese.gotCheese = false;
            CheeseCross.gameObject.SetActive(true);
            //Destroy(gameObject);
        }
    }
}