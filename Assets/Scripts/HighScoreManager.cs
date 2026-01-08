using System.IO;
using UnityEngine;
using System.Linq;
public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;

    private string filePath;
    public HighScoreData highScoreData = new HighScoreData();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        filePath = Application.persistentDataPath + "/highscores.json";
        LoadScores();
    }

public void AddScore(string playerName, int score)
{
    highScoreData.scores.Add(new HighScoreEntry(playerName, score));
 Debug.Log("GUARDANDO SCORE: " + playerName + " - " + score);
    highScoreData.scores = highScoreData.scores
        .OrderByDescending(x => x.score)
        .Take(3)
        .ToList();

    SaveScores();
}
    

    void SaveScores()
    {
         string json = JsonUtility.ToJson(highScoreData, true);
    Debug.Log("GUARDANDO ARCHIVO EN: " + filePath);

    File.WriteAllText(filePath, json);
    }

    public void LoadScores()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            highScoreData = JsonUtility.FromJson<HighScoreData>(json);
        }
    }
    public void ReloadScores()
{
    LoadScores();
}


}