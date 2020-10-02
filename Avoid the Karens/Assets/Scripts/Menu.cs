using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button StartGame;
    public Button GameCredits;
    public Button GameControls;
    public Button QuitGame;
    public Button HowTo;
    public Button ReturnMainMenu;
    public Button credits;

    public Image Infection;
    public const int InfectionMax = 100;
    public float InfectionAmount = 0;
    public float InfectionIncreaseAmount = 50;

    // public SceneFader SceneFader;

    public void Update()
    {
        InfectionAmount += InfectionIncreaseAmount * Time.deltaTime;
        InfectionAmount = Mathf.Clamp(InfectionAmount, 0f, InfectionMax);
        // Infection.fillAmount = infec.GetInfecNormalized();
        Infection.fillAmount = InfectionAmount / InfectionMax;

        if (InfectionAmount >= InfectionMax)
        {
            SceneManager.LoadScene("Game Level");
        }
    }

    public void PlayGamelevel()
    {
        SceneManager.LoadScene("Loading Scene");
        //SceneFader.FadTo("Loading");
    }

   // public void GameMenuCredits()
   // {
        // SceneManager.LoadScene("Credits");
        //SceneFader.FadTo("Credits");
    //}

    public void GameMenuControls()
    {
        SceneManager.LoadScene("Controls");
       //SceneFader.FadTo("Controls");
    }

   // public void GameObjectives()
   // {
        //SceneManager.LoadScene("HowToPlay");
      //  SceneFader.FadTo("HowToPlay");
   // }

  //  public void GoToCredits()
   // {
      //  SceneFader.FadTo("Credits");
    //}

    public void QuitGameMenu()
    {

#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


    public void ReturnMenu()
    {
        SceneManager.LoadScene("Main Menu");
        //SceneFader.FadTo("Menu");
    }
}
