using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{	
    public Text timerText; 
    public bool playing;
    private float _timer;
    public float timeRemaining;
    public Collisions Ron;
    public Collisions Jeff;

    public float maxHealth;
    public float currentHealth;
    public float health;

    public float maxInfect;
    public float currentInfect;
    public float infect;

    public Image healthBar;
    public Image infectBar;

    private void Start()
    {
        infectBar.fillAmount = 0;
    }

    void Update ()
    {
        //isSick = Collisions.sick;

        if (currentInfect <= maxInfect)
        {
            infect = currentInfect / maxInfect;
            infectBar.fillAmount = infect;
            
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            if (timeRemaining > 0 && Ron.sick == true)
            {
                timeRemaining -= (Time.deltaTime) * 10;
                currentInfect += 0.5f;
                infectBar.fillAmount = infect;
            }
        
            if (timeRemaining > 0 && Jeff.sick == true)
            {
                timeRemaining -= (Time.deltaTime) * 10;
                currentInfect += 0.5f;
                infectBar.fillAmount = infect;
            }
        
            if(playing == true)
            {
                timerText.text = timeRemaining.ToString("00");
            }
            infectBar.fillAmount = infect;
        }
        
        if (currentInfect >= maxInfect)
        {

            infectBar.fillAmount = infect;
            
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            if (timeRemaining > 0 && Ron.sick == true)
            {
                timeRemaining -= (Time.deltaTime) * 10;
                currentHealth -= 0.5f;
            }
        
            if (timeRemaining > 0 && Jeff.sick == true)
            {
                timeRemaining -= (Time.deltaTime) * 10;
                currentHealth -= 0.5f;
            }
            
            health = currentHealth / maxHealth;
            //Debug.Log(health);               
            healthBar.fillAmount = health;
        }
        
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

}
