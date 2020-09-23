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
}
