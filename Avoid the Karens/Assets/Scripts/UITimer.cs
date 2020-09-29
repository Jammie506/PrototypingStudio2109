using System;
using UnityEngine;
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
        
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining > 0 && Ron.sick == true)
        {
            timeRemaining -= (Time.deltaTime) * 10;
            currentInfect += 0.5f;
        }
        
        if (timeRemaining > 0 && Jeff.sick == true)
        {
            timeRemaining -= (Time.deltaTime) * 10;
            currentInfect += 0.5f;
        }
        
        if(playing == true)
        {
            timerText.text = timeRemaining.ToString("00");
        }
         
        infect = currentInfect / maxInfect; 
        Debug.Log(infect);
        infectBar.fillAmount = infect;

        if (infect == 1)
        {
            health = currentHealth / maxHealth;
            //Debug.Log(health);               
            healthBar.fillAmount = health;
        }
    }

}
