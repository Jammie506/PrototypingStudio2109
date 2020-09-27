using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    public GameObject Bread;
    public GameObject Cheese;
    public Image BreadCross;
    public Image CheeseCross;
    
    public bool picked;

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
            
        }
        else
        {
            picked = false;
        }
    }

    public void OnTriggerStay(Collider pickup)
    {
        if (gameObject == Bread && picked && pickup.gameObject.CompareTag("Player"))
        { 
            Debug.Log("Collected");
            Score.CoinAmount += 1;
            BreadCross.gameObject.SetActive(true);
            Destroy(gameObject);
        }
        if (gameObject == Cheese && picked && pickup.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collected");
            Score.CoinAmount += 2;
            CheeseCross.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
