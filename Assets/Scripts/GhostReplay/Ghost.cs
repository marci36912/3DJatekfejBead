using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost
{
    public Vector3 position { get; private set; }
    public Quaternion rotation { get; private set; }
    public float timestamp  { get; private set; }

    public Ghost(Vector3 pos, Quaternion rot, float time)
    {
        position = pos;
        rotation = rot;
        timestamp = time;
    }

    public Ghost getData()
    {
        return this;
    }
}
