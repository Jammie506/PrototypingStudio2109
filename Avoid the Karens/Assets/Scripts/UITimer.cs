using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{	
    public Text TimerText; 
    public bool playing;
    private float Timer;
    public float timeRemaining = 10;
    public Collisions Ron;
    public Collisions Jeff;

    /*void Start()
    {
        boob.sick = true;
    }*/
    
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
        }
        
        if (timeRemaining > 0 && Jeff.sick == true)
        {
            timeRemaining -= (Time.deltaTime) * 10;
        }
        
        if(playing == true)
        {
            TimerText.text = timeRemaining.ToString("00");
        }
    }

}
