using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer;
    private bool isTimerRunning;

    private const float startingTime = 1200f; // 20 minutes in seconds

    private void Start()
    {
        timer = startingTime;
        isTimerRunning = true;
        UpdateTimerText();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 0f;
                PauseTimer();
                Debug.Log("Timer reached 0 and was paused.");
            }
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timeString;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void PauseTimer()
    {
        isTimerRunning = false;
    }

    public void ResumeTimer()
    {
        isTimerRunning = true;
    }

    public void ResetTimer()
    {
        timer = startingTime;
        isTimerRunning = false;
        UpdateTimerText();
    }
}
