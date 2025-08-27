using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointManager : MonoBehaviour
{
    public TMP_Text scoreText;
  
    // Start is called before the first frame update
    void Start()
    {
         scoreText.text = "Score: " + GameManager.instance.score;
    }

    public void UpdateScore(int points)
    {
        GameManager.instance.score += points;
        scoreText.text = "Score: " + GameManager.instance.score;

   }
}
