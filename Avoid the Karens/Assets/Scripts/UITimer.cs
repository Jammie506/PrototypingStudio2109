using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{	
    public Text TimerText; 
    public bool playing;
    private float Timer;
    public float timeRemaining = 10;

    void Update () {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        
        if(playing == true)
        {
            TimerText.text = timeRemaining.ToString("00");
        }
    }

}
