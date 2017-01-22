using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pauseMenuScript1 : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject enemyStat;
    public GameObject player;

    public bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
        enemyStat.SetActive(false);
        player.SetActive(true);

    }

    void Update()
    {
        if(Input.GetButtonDown("A/X"))
        {
            
        }

        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            enemyStat.SetActive(true);
            player.SetActive(false);
            Time.timeScale = 1;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            enemyStat.SetActive(false);
            player.SetActive(true);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        paused = false;
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