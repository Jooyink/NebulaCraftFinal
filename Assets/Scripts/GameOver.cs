using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public static bool GameIsPaused = false;

         public GameObject isgameOver;

   private bool gameOverPlayed=false;
        

    // Update is called once per frame
    void Update()
    {
         if(GameManager.instance.vida == 0)
            {
                
                Riperoini();
            }
    }
 
    

    public void Riperoini()
    {

        if (gameOverPlayed) return;

        gameOverPlayed=true;

        
    isgameOver.SetActive(true);
    //pasueMenuUi.SetActive(false);
    //controlsUi.SetActive(false);

    //GameIsPaused = true;

    EventSystem.current.SetSelectedGameObject(null);
         AudioManager.instance.PlaySFX(AudioManager.instance.gameOvers);


    }
}
