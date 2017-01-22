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
    public GameObject tutorial;
    public Text changeText;
    private int randomNum;
    public AudioSource playSound;
    void Start()
    {
        tutorial.SetActive(false);
    }
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
    public void ExitButton_Click()
    {
		Application.Quit();
    }
    public void TutorialButton_Click()
    {
        tutorial.SetActive(true);
    }

    public void ChangetoScene (int changeScene)
    {
        SceneManager.LoadSceneAsync(changeScene);
    }
    public void TutorialButtonBack_CLick()
    {
        tutorial.SetActive(false);
    }
}
