using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

        public GameObject controlsUi;

        public GameObject ScoreUi;

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
        ScoreUi.SetActive(false);
    }
    public void Score()
    {

        ScoreUi.SetActive(true);
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}
