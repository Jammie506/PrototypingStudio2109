using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInfectionRadius : MonoBehaviour
{

    public float EnemyRadius = 10f;
    Transform playerTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, EnemyRadius);
    }
}
