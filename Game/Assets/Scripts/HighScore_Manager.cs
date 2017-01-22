using UnityEngine;
using System.Collections;
using System.IO;

public class HighScore_Manager : MonoBehaviour {

    private int[] scores = new int[10];
	// Use this for initialization
	void Start () {
	
	}

    void readTextFile(string file_path)
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

    void writeToTextFile(string file_path)
    {

    }
}
