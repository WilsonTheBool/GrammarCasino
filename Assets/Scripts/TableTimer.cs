using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TableTimer : MonoBehaviour
{
    
    private float timeSeconds = 0;
    public void StartTimer(float seconds)
    {
        timeSeconds = seconds;
    }

    public Action timerEnded;

    public void ResetTimer()
    {
        RemoveAllDelegates();
        timeSeconds = 0;
    }

    private void RemoveAllDelegates()
    {
        timerEnded = null;
    }

    void FixedUpdate()
    {
        if (timeSeconds > 0)
        {
            UpdateTime();
            UpdateUI();
        }
       
    }

    void UpdateTime()
    {
        
        timeSeconds -= Time.fixedDeltaTime;

        if (timeSeconds <= 0)
        {
            timeSeconds = 0;
            UpdateUI();
            timerEnded?.Invoke();
        }
       
    }

    [SerializeField]
    private UnityEngine.UI.Text timeText;
    void UpdateUI()
    {
        timeText.text = timeSeconds.ToString("F2");
    }
}
