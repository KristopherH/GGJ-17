using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GOMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Restart()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
