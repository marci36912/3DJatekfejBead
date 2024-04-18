using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> checkpoints;
    [SerializeField] private bool loop;
    private int index;
    private float time;

    private void Start() 
    {
        if(checkpoints.Count != 0)
        {
            resetCheckpoints();
        }
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
        Debug.Log($"Finished, {getTime()}");
        GameObject.Find("GhostRecorder").GetComponent<GhostRecorder>().finished();

        if(loop)
        {
            resetCheckpoints();
        }
    }

    private void resetCheckpoints()
    {
            time = Time.time;
            foreach (var checkpoint in checkpoints)
            {
                checkpoint.SetActive(false);
            }

            index = 0;
            checkpoints[index].SetActive(true);
    }
}
