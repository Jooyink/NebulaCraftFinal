using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int lives = 3;

    public Text scoreText;
    public Text livesText;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void TakeDamage(int damage)
    {
        lives -= damage;
        livesText.text = "Vidas: " + lives;

        if (lives <= 0)
        {
            SceneManager.LoadScene("OtraEscena"); // <- pon el nombre de tu segunda escena
        }
    }
}