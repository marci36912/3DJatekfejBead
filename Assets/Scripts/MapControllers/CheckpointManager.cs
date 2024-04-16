using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private bool lastCheckpoint()
    {
        return index == (checkpoints.Count - 1);
    }

    private void finished()
    {
        time = Time.time - time;
        Debug.Log($"vege, {time}");
    }
}
