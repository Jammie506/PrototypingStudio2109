using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ObjectCollections : MonoBehaviour
{
    public GameObject shelf;
    
    public Image breadCross;
    public Image cheeseCross;
    public Text dropControls;

    public Interactions interBread;
    public Interactions interCheese;

    public bool droppedBread;
    public bool droppedCheese;
    public bool on;

    private void Start()
    {
        breadCross.gameObject.SetActive(false);
        cheeseCross.gameObject.SetActive(false);
        dropControls.gameObject.SetActive(false);
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
        if (shelf.gameObject.CompareTag("Player") && interBread.picked && gameObject == this.shelf && interBread.gotBread)
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 1;
            interBread.gotBread = false;
            droppedBread = true;
            breadCross.gameObject.SetActive(true);
            //dropControls.gameObject.SetActive(true);
            
        } 
        else if (shelf.gameObject.CompareTag("Player") && interCheese.picked && gameObject == this.shelf && interCheese.gotCheese)
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 2;
            interCheese.gotCheese = false;
            droppedCheese = true;
            cheeseCross.gameObject.SetActive(true);
            //dropControls.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            on = true; 
            dropControls.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            on = false; 
            dropControls.gameObject.SetActive(false);
        }
    }
}