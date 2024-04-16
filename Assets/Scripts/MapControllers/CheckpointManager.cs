using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> checkpoints;
    private int index;
    private float time;

    private void Start() 
    {
        time = Time.time;
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.SetActive(false);
        }

        index = 0;
        checkpoints[index].SetActive(true);
    }

    public void nextIndex()
    {
        checkpoints[index].SetActive(false);
        
        if(lastCheckpoint())
        {
            finished();
        }
        else
        {
            index++;
            checkpoints[index].SetActive(true);
        }
    }

    public string getTime()
    {
        return $"{(int)(time / 60)}:{Math.Round(time - ((int)time/60)*60, 2)}";
    }

    private bool lastCheckpoint()
    {
        return index == (checkpoints.Count - 1);
    }

    private void finished()
    {
        time = Time.time - time;
        Debug.Log($"vege, {getTime()}");
    }
}
