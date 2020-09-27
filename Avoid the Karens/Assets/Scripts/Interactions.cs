using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    public GameObject Bread;
    public GameObject Cheese;

    public bool picked;

    /*public Image bread;
    public Image peas;
    public Image carrots;
    public bool imageOff =  false;*/
    
    void Start()
    {
        
        /*bread.gameObject.SetActive(false); 
        peas.gameObject.SetActive(false);
        carrots.gameObject.SetActive(false);*/
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            picked = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            picked = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (gameObject == Bread && picked)
        { 
            Debug.Log("Collected");
            Score.CoinAmount += 1;
            Destroy(gameObject);
        }

        else
       
        if (gameObject == Cheese && picked)
        {
            Debug.Log("Collected");
            Score.CoinAmount += 2;
            Destroy(gameObject);
        }
    }
}
