using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeTextManager : TextManager
{
    private float startingTime;

    public void setStartingTime(float time)
    {
        startingTime = time;
    }

    private void LateUpdate() 
    {
        float time =  Time.time - startingTime;
        changeText($"{(int)(time / 60)}:{(Math.Round(time - ((int)time/60)*60, 2)).ToString("00.0")}");
    }
}
