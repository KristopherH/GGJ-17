using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{


    private int lives = 3;
    private int score = 0;


    public Text scoreText;
    public Text livesText;

    // Use this for initialization
    
    private void Awake()
    {

        scoreText.text = "Current score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Current score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();

    }
   public void ScoreButton_Click()
    {
        score++;
    }
    public void livesButton_Click()
    {
        lives--;
    }
}

