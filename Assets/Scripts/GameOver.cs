using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject isgameOver;

    public TMP_InputField nameInput;
    public TMP_Text finalScoreText;

    private bool gameOverPlayed = false;

    void Update()
    {
        if (GameManager.instance.vida <= 0)
        {
            ShowGameOver();
        }
    }

    void ShowGameOver()
    {
        if (gameOverPlayed) return;

        gameOverPlayed = true;

        isgameOver.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);

        AudioManager.instance.PlaySFX(AudioManager.instance.gameOvers);

        //  Mostrar score final
        finalScoreText.text = GameManager.instance.score.ToString();
    }

    // BOTÓN "GUARDAR"
    public void SaveScoreAndContinue()
    {
         Debug.Log("BOTÓN GUARDAR PRESIONADO");
        string playerName = nameInput.text;

        if (string.IsNullOrEmpty(playerName))
            playerName = "PLAYER";

        HighScoreManager.instance.AddScore(
            playerName,
            GameManager.instance.score
        );

        SceneManager.LoadScene("ScoreBoard");

       

    }
}