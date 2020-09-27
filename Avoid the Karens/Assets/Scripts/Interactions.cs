using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    public GameObject Bread;
    public GameObject Cheese;
    public GameObject Shelf;
    
    public Renderer bRend;
    public Renderer cRend;
    
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

    public void OnTriggerStay(Collider enter)
    {
        if (enter.gameObject.CompareTag("Player") && picked && gameObject == Bread && !gotBread)
        {
            Debug.Log("Transferred");
                //Score.CoinAmount += 1;
                gotBread = true;
                //BreadCross.gameObject.SetActive(true);
                bRend.enabled = false;
                //Destroy(gameObject);
        }
        else if (enter.gameObject.CompareTag("Player") && picked && gameObject == Cheese && !gotCheese)
        {
            Debug.Log("Transferred");
                //Score.CoinAmount += 2;
                gotCheese = true;
                //CheeseCross.gameObject.SetActive(true);
                cRend.enabled = false;
                //Destroy(gameObject);
        } 
    }
}
