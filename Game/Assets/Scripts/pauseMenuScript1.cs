using UnityEngine;
using System.Collections;

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