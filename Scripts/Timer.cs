using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int CurrentTime;
    public float RestTime;
    private bool IsTimerOn;

    // Start is called before the first frame update
    void Start()
    {
        IsTimerOn = true;
        CurrentTime = (int)RestTime++;
    }

    // Update is called once per frame
    void Update()
    {
        TimerCheck();
    }

    private void TimerCheck()
    {
        if (IsTimerOn)
        {
            if (RestTime > 0)
            {
                RestTime -= Time.deltaTime;
            }
        }
        else
        {
            Debug.Log("Game Over!");
            RestTime = 0;
            IsTimerOn = false;
        }
        if (CurrentTime > (int)RestTime)
        {
            Debug.Log("Time: " + (int)RestTime);
            CurrentTime = (int)RestTime;
        }
    }
}
