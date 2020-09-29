using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCInfectionRadius : MonoBehaviour
{
    public Image Infection;

    
    public float EnemyRadius = 10f;
    Transform playerTarget;
    //public Infec infec;

    public const int InfectionMax = 100;
    public const int InfectionLeast = 0;
    public float InfectionAmount =0;
    public float DecreaseAmount =5;
    public float InfectionIncreaseAmount = 5;


    public Image healthbar;
    public const int maxHealth = 100;
    //public static float health;

    //public  float maxHealth = 100f;
    //public static float health;
    public  float HealthAmount = 0;
    public float HealthDecreaseAmount = 10;


    void Start()
    {
        playerTarget = PlayerManager.instance.player.transform;
        //healthbar = GetComponent<Image>();
        HealthAmount = maxHealth;
    }

    void Update()
    {
        float distance = Vector3.Distance(playerTarget.position, transform.position);
        if(distance <= EnemyRadius)
        {
            // infec.Update();
            InfectionAmount += InfectionIncreaseAmount * Time.deltaTime;
            InfectionAmount = Mathf.Clamp(InfectionAmount, 0f, InfectionMax);
           // Infection.fillAmount = infec.GetInfecNormalized();
            Infection.fillAmount = InfectionAmount / InfectionMax;
        }
        else if (distance >= EnemyRadius)
        {
            InfectionAmount -= DecreaseAmount * Time.deltaTime;
            InfectionAmount = Mathf.Clamp(InfectionAmount, 0f, InfectionMax);
            Infection.fillAmount = InfectionAmount / InfectionMax;
        }

        if (InfectionAmount >= InfectionMax)
        {
            HealthAmount -= HealthDecreaseAmount * Time.deltaTime;
            //healthbar.fillAmount = health / maxHealth;
            healthbar.fillAmount = HealthAmount / maxHealth;
        }

        if(HealthAmount <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, EnemyRadius);
    }
}
