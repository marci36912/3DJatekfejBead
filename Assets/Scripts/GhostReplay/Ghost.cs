using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost
{
    public Vector3 position { get; private set; }
    public Vector3 rotation { get; private set; }
    public float timestamp  { get; private set; }

    public Ghost(Vector3 pos, Vector3 rot, float time)
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
