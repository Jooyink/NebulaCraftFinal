using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pasueMenuUi;
    // Update is called once per frame
    public GameObject controlsUi;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {

                Resume();
            }
            else
            {
                Pause();
            }

        }

    }

    public void Resume()
    {
        pasueMenuUi.SetActive(false);
        controlsUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {   
        pasueMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void Controls()
    {
        controlsUi.SetActive(true);
        GameIsPaused = true;
    }
     
     public void Exit()
    {
        pasueMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
         SceneManager.LoadScene("MainMenu");

    }
}

