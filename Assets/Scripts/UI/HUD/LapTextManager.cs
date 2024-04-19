using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTextManager : TextManager
{
    private void Start() 
    {
        
    }
    public void lapcount(int lap)
    {
        changeText($"lap {lap}");
    }
}
