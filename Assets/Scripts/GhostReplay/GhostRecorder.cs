using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostRecorder : MonoBehaviour
{
    [SerializeField] private float frameTime;
    private Transform player;
    private float timer;
    private float startingTime;
    private List<Ghost> points;
    private bool notFinished;

    private void Start() 
    {
        startingTime = Time.time;
    }

    void Update()
    {
        if(timer <= 0 && notFinished)
        {
            points.Add(new Ghost(player.position, player.eulerAngles, (Time.time - startingTime)));
            timer = frameTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void finished()
    {
        GhostHolder tmp = GameObject.FindObjectOfType<GhostHolder>();
        if(tmp != null)
            tmp.setPoints(points);

        notFinished = false;
        points.Clear();
    }

    public void setData(Transform car)
    {
        points = new List<Ghost>();
        player = car;
        notFinished = true;
        timer = 0;

        Debug.Log("Recording started!");
    }
}
