using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> checkpoints;
    private bool loop;
    [SerializeField] private CheckpointTextManager checkpointTextManager;
    [SerializeField] private TimeTextManager timeTextManager;
    [SerializeField] private LapTextManager lapTextManager;
    private int index;
    private int lapIndex;
    private float time;

    private void Start() 
    {
        loop = MainMenu.isLooping;
        lapIndex = 0;
        if(checkpoints.Count != 0)
        {
            resetCheckpoints();
        }

        //checkpointTextManager = GameObject.Find("/HUD/CheckpointText").GetComponent<CheckpointTextManager>();
        //timeTextManager = GameObject.Find("/HUD/TimerText").GetComponent<TimeTextManager>();
        //lapTextManager = GameObject.Find("/HUD/Laps").GetComponent<LapTextManager>();
        checkpointTextManager.setMaxCheckpoint(checkpoints.Count);
    }

    public Transform lastCheckpointTransform()
    {
        return checkpoints[index == 0 ? 0 : index - 1].transform;
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

        checkpointTextManager.setCheckpoints(index);
    }

    public string getTime()
    {
        return $"Finished!\nYour time is:\n{(int)(time / 60)}:{Math.Round(time - ((int)time/60)*60, 2)}";
    }

    private bool lastCheckpoint()
    {
        return index == (checkpoints.Count - 1);
    }

    private void finished()
    {
        time = Time.time - time;
        Debug.Log($"{getTime()}");
        GameObject.Find("GhostRecorder").GetComponent<GhostRecorder>().finished();
        UIManager.gameEnded(getTime());

        AudioListener.volume = 0;
        Time.timeScale = loop ? 1 : 0;

        if(loop)
        {
            resetCheckpoints();
        }
    }

    private void resetCheckpoints()
    {
        Time.timeScale = 1;
            time = Time.time;
            timeTextManager.setStartingTime(time);
            foreach (var checkpoint in checkpoints)
            {
                checkpoint.SetActive(false);
            }

            index = 0;
            lapIndex++;
            checkpoints[index].SetActive(true);

            lapTextManager.lapcount(lapIndex);
    }
}
