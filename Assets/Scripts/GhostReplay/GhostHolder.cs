using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHolder : MonoBehaviour
{
    private static List<Ghost> _points;

    public void setPoints(List<Ghost> points)
    {
        _points = points;

        Debug.Log("Recording done");
    }

    public List<Ghost> getPoints()
    {
        Debug.Log("points set");
        return _points;
    }
}
