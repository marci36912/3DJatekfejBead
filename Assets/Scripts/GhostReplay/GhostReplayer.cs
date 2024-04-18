using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReplayer : MonoBehaviour
{
    [SerializeField] private GameObject carGhost;
    private GameObject ghost;
    private List<Ghost> points;
    private int index;
    float c;
    
    void Start()
    {
        startReplay();
        c = Time.time;
    }
    void Update()
    {
        if((points[index].timestamp + c) <= Time.time)
        {
            Debug.Log($"{points[index].position}  {points[index].rotation.eulerAngles} {index}/{points.Count}\n{points[index].timestamp + c}/{Time.time}");
            ghost.transform.position = points[index].position;
            ghost.transform.rotation = points[index].rotation;

            index = index+1 < points.Count ? index+1 : index;
        }
    }

    public void startReplay()
    {
        GhostHolder tmp = GameObject.FindObjectOfType<GhostHolder>();
        points = tmp.getPoints();
        ghost = Instantiate(carGhost, transform);
        Debug.Log("Replay started");
        index = 0;

        if(points == null || points.Count == 0)
            Destroy(gameObject);
    }
}
