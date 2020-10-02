using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    Text text;
    
    public static float CoinAmount;

    void Start()
    {
        text = GetComponent<Text>();
        CoinAmount = 0;
    }

    void Update()
    {
        text.text = CoinAmount.ToString();

        if( CoinAmount >= 14)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
