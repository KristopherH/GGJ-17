using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class playerTimer : MonoBehaviour {

    public TextMesh totalTimePlayedText;
    public TextMesh cookingTimerText;

    public float cTimer = 0;
    private float startTime;

    private bool isCooking = true;
    public int enemyType;

    // Use this for initialization
    void Start() {
        startTime = Time.time;
		if(totalTimePlayedText != null) totalTimePlayedText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        totalTime();

        if (isCooking)
        {
            enemyTimer();
        }
        if (cTimer <= 0)
        {
            isCooking = false;
        }
    }

	public void setCookingTimer(float seconds)
    {
		cTimer = seconds;
        isCooking = true;

    }

    void enemyTimer()
    {
        cTimer -= Time.deltaTime;
		String timerText = cTimer.ToString("f0");
		if (cTimer <=9){
			cookingTimerText.text = "00:0" + timerText;
		} else {
			cookingTimerText.text = "00:" + timerText;
		}
    }

    void totalTime()
    {
        float t = Time.time - startTime;
        string fMinutes = ((int)t / 60).ToString();
        string fSeconds = (t % 60).ToString("f0");
		if (totalTimePlayedText == null)
			return;
		totalTimePlayedText.text = fMinutes + ":" + fSeconds;
    }    
}
