using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;


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
    // infection rate and health
    public Image Infection;

    public float enemyRadius = 10f;
    Transform playerTarget;

    public const int InfectionMax = 100;
    public const int InfectionLeast = 0;
   
    public float infectionAmount =0;
    public float decreaseAmount =5;
    public float infectionIncreaseAmount = 5;

    public Image healthbar;
    public const int maxHealth = 100;
    
    public  float HealthAmount = 0;
    public float HealthDecreaseAmount = 10;

    public UITimer timer;
    public Text Text;

   public Animator anim;
   public bool walking = false;

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
         walking = true;
         anim.SetBool("Walking" ,walking); 
        anim = GetComponent<Animator>();
        // Disable to make NPC move constantly
        agent.autoBraking = false;

        GotoNextPoint();
        //OnCollisionEnter();

        StartCoroutine("FindTargetsWithDelay", .2f);
        
        playerTarget = PlayerManager.instance.player.transform;
        //healthbar = GetComponent<Image>();
        HealthAmount = maxHealth;
        
       
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


        UpdateInfection();

       /* float distance = Vector3.Distance(playerTarget.position, transform.position);
        if(distance <= enemyRadius)
        {
            // infec.Update();
            infectionAmount += infectionIncreaseAmount * Time.deltaTime;
            infectionAmount = Mathf.Clamp(infectionAmount, 0f, InfectionMax);
            // Infection.fillAmount = infec.GetInfecNormalized();
            //Infection.fillAmount = infectionAmount / InfectionMax;
            Text.text = infectionAmount.ToString();
        }
        else if (distance >= enemyRadius)
        {
            infectionAmount -= decreaseAmount * Time.deltaTime;
            infectionAmount = Mathf.Clamp(infectionAmount, 0f, InfectionMax);
            // Infection.fillAmount = infectionAmount / InfectionMax;
            Text.text = infectionAmount.ToString(); 
        }

        if (infectionAmount >= InfectionMax)
        {
            HealthAmount -= HealthDecreaseAmount * Time.deltaTime;
            //healthbar.fillAmount = health / maxHealth;
            healthbar.fillAmount = HealthAmount / maxHealth;
        }

        if(HealthAmount <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        */
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
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,enemyRadius);
    }


   


    
   
    
    private bool hasInfected;
   

    private void UpdateInfection()
    {
        float distance = Vector3.Distance(playerTarget.position, transform.position);
        if (distance <= enemyRadius)
        {
           
            if (!hasInfected)
            {
                hasInfected = true;
                PlayerManager.infectionMultiplier++;
            }
        }
        else
        {
            

            if (hasInfected)
            {
                hasInfected = false;
                PlayerManager.infectionMultiplier--;
            }
        }
    }
}
