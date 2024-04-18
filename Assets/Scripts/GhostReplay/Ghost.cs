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

    public Ghost(string line)
    {
        string[] values = line.Split(' ');

        if(values.Length == 7)
            setValues(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]), float.Parse(values[3]), float.Parse(values[4]), float.Parse(values[5]), float.Parse(values[6]));
    }

    private void setValues(float positionX, float positionY, float positionZ, float rotationX, float rotationY, float rotationZ, float time)
    {
        position = new Vector3(positionX, positionY, positionZ);
        rotation = new Vector3(rotationX, rotationY, rotationZ);
        timestamp = time;
    }

    public override string ToString()
    {
        return $"{position.x} {position.y} {position.z} {rotation.x} {rotation.y} {rotation.z} {timestamp}";
    }
}
