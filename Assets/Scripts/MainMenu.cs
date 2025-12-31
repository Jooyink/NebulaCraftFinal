using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainMenu : MonoBehaviour
{

  public GameObject PlayButton;
    void Start()
    { 
        
        
        EventSystem.current.SetSelectedGameObject(null);
    EventSystem.current.SetSelectedGameObject(PlayButton);
    }

    public GameObject controlsUi;

        public GameObject ScoreUi;

    public void PlayGame()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.uiClickSFX);

        SceneManager.LoadScene("Cinematic");
    }

       public void Controls()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.uiClickSFX);

        controlsUi.SetActive(true);
    }

    public void Resume()
    {
                AudioManager.instance.PlaySFX(AudioManager.instance.uiClickSFX);

        controlsUi.SetActive(false);
        ScoreUi.SetActive(false);
    }
    public void Score()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.uiClickSFX);

        ScoreUi.SetActive(true);
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}
