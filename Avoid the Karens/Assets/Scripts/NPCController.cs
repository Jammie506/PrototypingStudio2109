using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class NPCController : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    void Start () {
        agent = GetComponent<NavMeshAgent>();

        // Disable to make NPC move constantly
        agent.autoBraking = false;

        GotoNextPoint();
        //OnCollisionEnter();
    }


    void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Tells them where to go first
        agent.destination = points[destPoint].position;

        // Picks the next location, restarting the loop is the end is reached
        destPoint = (Random.Range(0, points.Length)) % points.Length;
    }

    void Update () {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Jeff")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }
}
