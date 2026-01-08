using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainMenu : MonoBehaviour
{
    public float delayBeforeLoad = 4f; // duración del sonido
    public GameObject scorePanel;
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
                StartCoroutine(LoadSceneAfterDelay());


        SceneManager.LoadScene("Cinematic");
    }

       public void Controls()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.uiClickSFX);

        controlsUi.SetActive(true);
    }

    IEnumerator LoadSceneAfterDelay()
    {
         yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene("Cinematic");
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

    public void OpenScoreBoard()
{   
      AudioManager.instance.PlaySFX(AudioManager.instance.uiClickSFX);
    HighScoreManager.instance.ReloadScores();
    scorePanel.SetActive(true);
}

public void CloseScorePanel()
    {
        scorePanel.SetActive(false);
    }

}
