using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    void OnTriggerEnter(Collider col2)
    {
        if (col2.gameObject.tag == "Player")
        {
            Debug.Log("I'm a Genius");
        }
    }
}

