using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public bool sick = false;
    
    void OnTriggerEnter(Collider col2)
    {
        if (col2.gameObject.tag == "Player")
        {
            sick = true;
            
            Debug.Log("I'm a Genius");
        }
        else
        {
            sick = false;
        }
    }
}

