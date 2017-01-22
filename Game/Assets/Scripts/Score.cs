using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    static private int score_length = 6;
    private int[] scores = new int[score_length];
    private bool[] incScore = new bool[score_length];
    
    public Text scoreText;

	static Score _instance;
	public static Score Instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<Score> ();
			return _instance;
		}
	}

    // Use this for initialization
    private void Awake()
    {
        for (int i = 0; i < score_length; i++)
        {
            scores[i] = 0;
            incScore[i] = true;
        }
		increaseScore(0);

	}

    // Update is called once per frame
    void Update()
    {

        //scoreText.text = "";
		//increaseScore();
       
    }

    public void increaseScore(int score = 1)
    {
		scoreText.text = "";
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
}

