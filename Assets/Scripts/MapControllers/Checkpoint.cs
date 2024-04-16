using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    private void Start() 
    {
        checkpointManager = GameObject.Find("CheckpointManager").GetComponent<CheckpointManager>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("" + other.gameObject.name);
        if(other.tag == "Player")
        {
            checkpointManager.nextIndex();
        }
    }
}
