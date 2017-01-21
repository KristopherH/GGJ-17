using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{


    //private int lives = 2;

    static private int score_length = 6;
    private int[] scores = new int[score_length];
    private bool[] incScore = new bool[score_length];
    

    public Text scoreText;
    //public Text livesText;

    // Use this for initialization
    
    private void Awake()
    {
       
        for (int i = 0; i < score_length; i++)
        {
            scores[i] = 0;
            incScore[i] = true;
        }
        //scoreText.text = "Current score: " + score.ToString();
        //livesText.text = "Lives: " + lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "";
        //livesText.text = "Lives: " + lives.ToString();
        //scores++;
        increaseScore();
    }
    void increaseScore(int score = 1)
    {
        scores[0] += score;

        for (int i = score_length - 1; i >= 0; i--)
        {
            if (scores[i] >= 9)
            {
                incScore[i] = false;
            }
            else break;
        }

        for (int i = 0; i < score_length - 1; i++)
        {
            if (incScore[i] && scores[i] >= 10)
            {
                scores[i] = 0;
                scores[i + 1]++;
            }
            else break;
        }

        for (int i = score_length - 1; i >= 0; i--)
        {
            scoreText.text = scoreText.text + scores[i].ToString();
        }

    }




    public void ScoreButton_Click()
    {
        //score++;
    }
    public void livesButton_Click()
    {
        //lives--;
    }
}

