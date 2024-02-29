using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] float speed;
    private float currentFov;
    private void Start() 
    {
        //TODO legyen smooth a zoom
        currentFov = 60f;
    }
    void FixedUpdate()
    {
        currentFov += Input.GetAxis("Mouse ScrollWheel") * speed;
        Camera.main.fieldOfView = currentFov;
    }
}
