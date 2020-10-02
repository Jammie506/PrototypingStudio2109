using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ObjectCollections : MonoBehaviour
{
    public GameObject shelf;
    
    public Image breadCross;
    public Image cheeseCross;
    public Image milkCross;
    public Image waterCross;
    public Image cokeCross;
    public Image vegCross;
    public Image meatCross;
    public Text dropControls;

    public Interactions interBread;
    public Interactions interCheese;
    public Interactions interMilk;
    public Interactions interWater;
    public Interactions interCoke;
    public Interactions interVeg;
    public Interactions interMeat;

    public bool droppedBread;
    public bool droppedCheese;
    public bool droppedMilk;
    public bool droppedWater;
    public bool droppedCoke;
    public bool droppedVeg;
    public bool droppedMeat;
    public bool on;

    private void Start()
    {
        breadCross.gameObject.SetActive(false);
        cheeseCross.gameObject.SetActive(false);
        milkCross.gameObject.SetActive(false);
        waterCross.gameObject.SetActive(false);
        cokeCross.gameObject.SetActive(false);
        vegCross.gameObject.SetActive(false);
        meatCross.gameObject.SetActive(false);
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
        if (interCheese.gotMilk)
        {
            droppedMeat= false;
        }
        if (interCheese.gotWater)
        {
            droppedWater= false;
        }
        if (interCheese.gotCoke)
        {
            droppedCoke= false;
        }
        if (interCheese.gotVeg)
        {
            droppedVeg= false;
        }
        if (interCheese.gotMeat)
        {
            droppedMeat= false;
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
        else if (shelf.gameObject.CompareTag("Player") && interMilk.picked && gameObject == this.shelf && interMilk.gotMilk)
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 3;
            interMilk.gotMilk = false;
            droppedMilk = true;
            milkCross.gameObject.SetActive(true);
            //dropControls.gameObject.SetActive(true);
        }
        else if (shelf.gameObject.CompareTag("Player") && interWater.picked && gameObject == this.shelf && interWater.gotWater)
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 1;
            interWater.gotWater = false;
            droppedWater = true;
            waterCross.gameObject.SetActive(true);
            //dropControls.gameObject.SetActive(true);
        }
        else if (shelf.gameObject.CompareTag("Player") && interCoke.picked && gameObject == this.shelf && interCoke.gotCoke)
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 4;
            interCoke.gotCoke = false;
            droppedCoke = true;
            cokeCross.gameObject.SetActive(true);
            //dropControls.gameObject.SetActive(true);
        }
        else if (shelf.gameObject.CompareTag("Player") && interVeg.picked && gameObject == this.shelf && interVeg.gotVeg)
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 2;
            interVeg.gotVeg = false;
            droppedVeg = true;
            vegCross.gameObject.SetActive(true);
            //dropControls.gameObject.SetActive(true);
        }
        else if (shelf.gameObject.CompareTag("Player") && interMeat.picked && gameObject == this.shelf && interMeat.gotMeat)
        { 
            Debug.Log("Dropped");
            Score.CoinAmount += 2;
            interMeat.gotMeat = false;
            droppedMeat = true;
            meatCross.gameObject.SetActive(true);
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