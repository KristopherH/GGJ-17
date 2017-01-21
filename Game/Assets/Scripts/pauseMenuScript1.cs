using UnityEngine;
using System.Collections;

public class pauseMenuScript1 : MonoBehaviour {

    public GameObject PauseUI;
    public GameObject enemyStats;

    public bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
        enemyStats.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            enemyStats.SetActive(true);
            Time.timeScale = 0;
        }
        if(!paused)
        {
            PauseUI.SetActive(false);
            enemyStats.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        paused = false;
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void MainMenu()
    {
        Application.LoadLevel(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
