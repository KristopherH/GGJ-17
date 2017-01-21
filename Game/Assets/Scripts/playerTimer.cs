using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class playerTimer : MonoBehaviour {

    public TextMesh totalTimePlayedText;
    public TextMesh cookingTimerText;

    private float cTimer = 0;
    private float startTime;

    private bool isCooking = true;
    private bool newEnemy = true;
    public int enemyType;

    // Use this for initialization
    void Start() {
        startTime = Time.time;
        totalTimePlayedText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        totalTime();
        
        if (newEnemy)
        {
          cookingTimerText.gameObject.SetActive(true);
          getEnemyType();
          setCookingTimer();
        }
        if (isCooking)
        {
            enemyTimer();
        }
        if (cTimer <= 0)
        {
            isCooking = false;
        }
    }

    int getEnemyType()
    {
        return enemyType;
    }

    void setCookingTimer()
    {
        if (enemyType == 1)
        {
            cTimer = 3;
        }
        else if (enemyType == 2)
        {
            cTimer = 10;
        }
        else if (enemyType == 3)
        {
            cTimer = 30;
        }

        newEnemy = false;
        isCooking = true;

    }

    void enemyTimer()
    {
        cTimer -= Time.deltaTime;
        cookingTimerText.text = cTimer.ToString("f0");
    }

    void totalTime()
    {
        float t = Time.time - startTime;
        string fMinutes = ((int)t / 60).ToString();
        string fSeconds = (t % 60).ToString("f0");
        totalTimePlayedText.text = fMinutes + ":" + fSeconds;
    }    
}
