using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class NPCController : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public float viewRadius;
    [Range(0,306)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obsticleMask;
    public bool See = false;

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void Start () {
        agent = GetComponent<NavMeshAgent>();

        // Disable to make NPC move constantly
        agent.autoBraking = false;

        GotoNextPoint();
        //OnCollisionEnter();

        StartCoroutine("FindTargetsWithDelay", .2f);
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
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hi");
        }
    }

    void FindVisibleTargets()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obsticleMask))
                {
                    See = true;
                    Debug.Log("I See You");
                }
            }
        }
    }
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        
    }
}
