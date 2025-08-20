using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {

        SceneManager.LoadScene("Cinematic");
    }

       public void Controls()
    {

        SceneManager.LoadScene("Controls");
    }

      public void Credits()
    {

        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}
