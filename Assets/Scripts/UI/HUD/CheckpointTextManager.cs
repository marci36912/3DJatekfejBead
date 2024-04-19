using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointTextManager : TextManager
{
    private int maxCheckpoint;
    private int currectCheckpoint;
    public void setMaxCheckpoint(int max)
    {
        maxCheckpoint = max;
        currectCheckpoint = 0;
    }
    public void setCheckpoints(int currect)
    {
        currectCheckpoint = currect;
        changeText($"{currectCheckpoint+1}/{maxCheckpoint}");
    }
}
