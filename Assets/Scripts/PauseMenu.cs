using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pasueMenuUi;
    // Update is called once per frame
    public GameObject controlsUi;

    public GameObject ResumeButton;

    PlayerControls controls;
    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Pause.performed += ctx => Pause();

        
    }
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
                AudioManager.instance.PlaySFX(AudioManager.instance.uiClickSFX);

        pasueMenuUi.SetActive(false);
        controlsUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
                AudioManager.instance.PlaySFX(AudioManager.instance.uiClickSFX);

        pasueMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        EventSystem.current.SetSelectedGameObject(null);
    EventSystem.current.SetSelectedGameObject(ResumeButton);

    }

    public void Controls()
    {
                AudioManager.instance.PlaySFX(AudioManager.instance.uiClickSFX);

        controlsUi.SetActive(true);
        GameIsPaused = true;
    }

    public void Exit()
    {
                AudioManager.instance.PlaySFX(AudioManager.instance.uiClickSFX);

        pasueMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");

    }

   
    
    void OnEnable()
{
    controls.Enable();
}

void OnDisable()
{
    controls.Disable();
}
}

