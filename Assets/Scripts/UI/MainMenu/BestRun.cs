using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
public class BestRun : TextManager
{
    void Start()
    {
        GhostHolder ghostHolder = GameObject.Find("SaveLoader").GetComponent<GhostHolder>();
        if(ghostHolder != null)
        {
            changeText(ghostHolder.getData());
        }
        else
        {
            changeText("");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
