using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour
{
    public float totalTime = 120f;
    public TextMeshProUGUI timerText; //used for showing countdown from 3,2,1 
    public TextMeshProUGUI winText;

    private void Start()
    {
        timerText.text = "";
        winText.text = "";
    }

    void Update()
    {
        totalTime -= Time.deltaTime;

        UpdateLevelTimer(totalTime);

        SetWinText();
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    void SetWinText()
    {
        if (totalTime <= 0f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
