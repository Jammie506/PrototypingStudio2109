using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public GameObject CoinSingle;
    public GameObject CoinDouble;

    public Image bread;
    public Image peas;
    public Image carrots;
    public bool imageOff =  false;
    // Start is called before the first frame update
    void Start()
    {
        bread.gameObject.SetActive(false); 
        peas.gameObject.SetActive(false);
        carrots.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
       
            if (gameObject == CoinDouble && !imageOff)
            {

            imageOff = true;
            peas.gameObject.SetActive(true);
            carrots.gameObject.SetActive(true);
            Debug.Log("work");
            Score.CoinAmount += 1;
            Destroy(gameObject);
        }

         else
       
        if (gameObject == CoinSingle && !imageOff)
        {

            imageOff = true;
            bread.gameObject.SetActive(true);
            Debug.Log("work single");
            Score.CoinAmount += 2;
            Destroy(gameObject);
        }
    }
}
