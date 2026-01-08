using TMPro;
using UnityEngine;

public class ScoreBoardUI : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text[] nameTexts;   // Izquierda
    public TMP_Text[] scoreTexts;  // Derecha

    

    void OnEnable() // 🔹 mejor que Start para paneles
    {
        RefreshBoard();
    }

    void RefreshBoard()
    {
        var scores = HighScoreManager.instance.highScoreData.scores;

        for (int i = 0; i < 3; i++)
        {
            if (i < scores.Count)
            {
                nameTexts[i].text = scores[i].playerName;
                scoreTexts[i].text = scores[i].score.ToString();
            }
            else
            {
                nameTexts[i].text = "---";
                scoreTexts[i].text = "00";
            }
        }
    }
}