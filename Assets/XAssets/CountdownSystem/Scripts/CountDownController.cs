using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public static CountDownController Instance;
    public Text TextCountdown;
    private float CountDownTime;
    private bool startCountdown = false;
    private Action FinishFunction;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
            
    }

    void Update()
    {
        if (startCountdown)
        {
            Countdown();
        }
    }

    public void StartCountdown(float countDownTime, Action finisFunc)
    {
        FinishFunction = finisFunc;
        CountDownTime = countDownTime;
        startCountdown = true;
    }

    public void StopCountdown()
    {
        startCountdown = false;
    }

    private void Countdown()
    {
        if (CountDownTime > 0)
        {
            CountDownTime -= Time.deltaTime;
            SetLevelTime(CountDownTime);
        }
        else
        {
            //LEVEL COUNTDOWN OVER !!!!!!!!!!!!!
            startCountdown = false;
            FinishFunction();
        }
    }

    private void SetLevelTime(float countdown)
    {
        if (countdown >= 0)
        {
            TimeSpan time = TimeSpan.FromSeconds(countdown);
            DateTime dateTime = DateTime.Today.Add(time);
            string displayTime = dateTime.ToString("mm:ss");

            CountDownTime = countdown;
            TextCountdown.text = displayTime;
        }
    }       
    


}
