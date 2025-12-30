using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 📌 Singleton (para que todos los scripts puedan acceder)
    public static GameManager instance;

    //VARIABLES
    public int vida = 3;


    public int score=0;
    public int sumarscore = 10;
    public int MaxScore;

    public PauseMenu pauseMenu;




    private void Awake()
    {
        // Configurar Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarVida()
    {
        

    }

    public void QuitarVida()
    {

        vida--;   

   
}


    

    

    public void AgregarScore()
    {
        score = +sumarscore;
        Debug.Log("Score :" + score);
     


    }

    public void GameOver()
    {
        Debug.Log("GameOver :( ");
         SceneManager.LoadScene("GameOver");
                   
    }
}
