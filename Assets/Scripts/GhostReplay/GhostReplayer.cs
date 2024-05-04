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
        if((points[index+1].timestamp + c) <= Time.time)
        {
            index = index+2 < points.Count ? index+1 : index;
            ghost.transform.eulerAngles = points[index].rotation;
        }

        smoothMovement(points[index].timestamp + c, points[index+1].timestamp + c,
                       points[index].position, points[index+1].position,
                       points[index].rotation, points[index+1].rotation);
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

    private void smoothMovement(float startTime, float endTime, Vector3 startPosition, Vector3 endPosition, Vector3 startRotation, Vector3 endRotation)
    {
        float t = Mathf.Clamp((Time.time - startTime)/(endTime - startTime), 0.0f, 1.0f);
        ghost.transform.position = Vector3.Lerp(startPosition, endPosition, t);
        Quaternion start = Quaternion.Euler(startRotation);
        Quaternion end = Quaternion.Euler(endRotation);
        transform.rotation = Quaternion.Lerp(start, end, t);
    }
}
