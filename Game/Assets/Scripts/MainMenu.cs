using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    // Use this for initialization
    // Update is called once per frame
    private bool clicked = false; 
    public float speed =  2.0f;
    public Text changeText;
    private int randomNum;

    void Update () {
        if (clicked == true)
        {
            transform.Translate(0,0, speed * Time.deltaTime);
            switch (randomNum)
            {
                case 0:
                    changeText.text = "RUM IS GOOD";
                    break;
                case 1:
                    changeText.text = "FEED ME";
                    break;
                case 2:
                    changeText.text = "GET IN ME";
                    break;
                case 3:
                    changeText.text = "MEOW";
                    break;
                case 4:
                    changeText.text = "!Cake";
                    break;
            }
            
        }
   
	}
    public void PlayButton_Click()
    {
        clicked = true;
        randomNum = Random.Range(0, 5);

    }
}
