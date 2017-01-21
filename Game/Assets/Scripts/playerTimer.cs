using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class playerTimer : MonoBehaviour {

    public Text totalTimePlayedText;
    public Text cookingTimerText;

    private float cTimer = 0;
    private float startTime;

    private bool isCooking = false;
    private bool newEnemy = true;
    public int enemyType;

    // Use this for initialization
    void Start() {
        startTime = Time.time;
        cookingTimerText = GetComponent<Text>();
        totalTimePlayedText.enabled = false;
    }

    // Update is called once per frame
    void Update() {

       // gameObject.transform.FindChild("TimerText").gameObject.GetComponent<Text>().enabled = false;
        totalTime();
        
        if (newEnemy)
        {
          cookingTimerText.enabled = true;
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
            cookingTimerText.text = "Feed Me";
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
        cookingTimerText.text = cTimer.ToString("f0") + "s";
    }

    void totalTime()
    {
        float t = Time.time - startTime;
        string fMinutes = ((int)t / 60).ToString();
        string fSeconds = (t % 60).ToString("f0");
        totalTimePlayedText.text = fMinutes + ":" + fSeconds;
    }    
}
