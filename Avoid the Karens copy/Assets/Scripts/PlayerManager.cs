using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public static float infectionAmount;
    public static float infectionMultiplier;
    public float DecreaseAmount = 5;
    public float InfectionIncreaseAmount = 5;
    public const int InfectionMax = 100;
    public Text text;

    public Image healthbar;
    public const int maxHealth = 100;
    //public static float health;

    //public  float maxHealth = 100f;
    //public static float health;
    public float HealthAmount = 100;
    public float HealthDecreaseAmount = 10;

    public void Start()
    {
        infectionAmount = 0;
        infectionMultiplier = 0;
    }
    public void Update()
    {
        if(infectionMultiplier != 0)
        {
            infectionAmount += InfectionIncreaseAmount * infectionMultiplier * Time.deltaTime;
        }
        else
        {
            infectionAmount -= DecreaseAmount * Time.deltaTime;
        }

        infectionAmount = Mathf.Clamp(infectionAmount, 0f, InfectionMax);

        text.text = (int)infectionAmount + "";


        if (infectionAmount >= InfectionMax)
        {
            HealthAmount -= HealthDecreaseAmount * Time.deltaTime;
            //healthbar.fillAmount = health / maxHealth;
            healthbar.fillAmount = HealthAmount / maxHealth;
        }

        if (HealthAmount <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }



    }
}
