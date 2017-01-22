using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;

public class MainMenu : MonoBehaviour {

    // Use this for initialization
    // Update is called once per frame
    private bool clicked = false; 
    public float speed =  2.0f;
    public Text changeText;
    private int randomNum;
    public AudioSource playSound;
    void Start()
    {
    }
    void Update () {
        if (clicked == true)
        {
            transform.Translate(0,0, speed * Time.deltaTime);
            switch (randomNum)
            {
                case 0:
                    changeText.text = "Go Shawty \n It's sherbert day";
                    break;
                case 1:
                    changeText.text = "Feed Me";
                    break;
                case 2:
                    changeText.text = "Wu Tang Flan";
                    break;
                case 3:
                    changeText.text = "MEOW";
                    break;
                case 4:
                    changeText.text = "!Cake";
                    break;
                case 5:
                    changeText.text = "Blurred Limes";
                    break;
                case 6:
                    changeText.text = "Send Foods";
                    break;
                case 7:
                    changeText.text = "Robert Brownie Jr.";
                    break;
                case 8:
                    changeText.text = "B*tch Peas";
                    break;
            }
            
        }
   
	}

    public void PlayButton_Click()
    {
        clicked = true;
        randomNum = Random.Range(0, 5);
        SceneManager.LoadSceneAsync(2);

    }
    public void ExitButton_Click()
    {
		Application.Quit();
    }
    public void TutorialButton_Click()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void HighScore_Click()
    {
        SceneManager.LoadSceneAsync(4);
    }
}
