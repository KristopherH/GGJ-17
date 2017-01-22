using UnityEngine;
using System.Collections;
using System.IO;

public class HighScore_Manager : MonoBehaviour {

    private int[] scores = new int[10];

    void Awake()
    {
        readTextFile();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            updateList(10);
            Debug.Log("Updating values");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            writeToTextFile();
            Debug.Log("Writing to file");
        }
    }

    public void readTextFile(string file_path = "C:\\Users\\K_Hil\\Desktop\\Highscore.txt")
    {
        StreamReader inp_stm = new StreamReader(file_path);
        int i = 0;
        while (!inp_stm.EndOfStream)
        {
            string intput = inp_stm.ReadLine();
             
            scores[i] = int.Parse(intput);
            i++;
        }

        inp_stm.Close();
    }

    public void updateList(int player_score)
    {
        bool is_high_score = false;
        int new_score_position = 0;
        for(int i = 0; i < 10; i++)
        {
            if(player_score > scores[i])
            {
                is_high_score = true;
                new_score_position = i;
            }
        }

        if(is_high_score)
        {
            for(int i = 9; i > new_score_position; i--)
            {
                scores[i] = scores[i - 1];
            }

            Debug.Log(player_score.ToString());
            scores[new_score_position] = player_score;
            Debug.Log(scores[new_score_position].ToString());
        }
    }

    public void writeToTextFile(string file_path = "C:\\Users\\K_Hil\\Desktop\\Highscore.txt")
    {
        using (System.IO.StreamWriter file =
               new System.IO.StreamWriter(@"C:\Users\K_Hil\Desktop\Highscore.txt"))
        {
            for (int i = 0; i < 10; i++)
            {
                string score_string = scores[i].ToString();
                Debug.Log(score_string);
                file.WriteLine(score_string + "\n");
            }

            file.Close();
         }
    }
}
