using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

        public GameObject controlsUi;

    public void PlayGame()
    {

        SceneManager.LoadScene("Cinematic");
    }

       public void Controls()
    {

        controlsUi.SetActive(true);
    }

     public void Resume()
    {
        controlsUi.SetActive(false);
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
