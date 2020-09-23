using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{

    public NavMeshAgent naveMeshAgent;
    public bool walking = false;


    // Start is called before the first frame update
    void Start()
    {
        naveMeshAgent.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                naveMeshAgent.destination = hit.point;
            }
        }

        if(naveMeshAgent.remainingDistance <= naveMeshAgent.stoppingDistance)
        {
            walking = false;
        }
        else
        {
            walking = true;
        }
    }
}
