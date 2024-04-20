using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    private Timer timer;

    public TMP_Text scoreText;
    public float currentScore;

    private void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }


    private void Update()
    {
        TimeScoreManager();
    }

    private void TimeScoreManager()
    {
        float newTimeRemaining = (timer.remainingTime / timer.startingTime);
        currentScore = Mathf.Lerp(0, 100, newTimeRemaining);
        int intVal = Mathf.FloorToInt(currentScore);
        scoreText.text = intVal.ToString();

        PlayerPrefs.SetString("PlayerScore", scoreText.text);

    }


}











