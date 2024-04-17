using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private CameraRotator rotatePoint;
    private float horizontal, vertical;

    private void OnEnable() 
    {
        rotatePoint = GameObject.Find("Camerarotator").GetComponent<CameraRotator>();
        //transform.position = offset;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("HorizontalCamera");
        vertical = Input.GetAxis("VerticalCamera");

        rotateCamera();
    }

    private void rotateCamera()
    {
        rotatePoint.RotateCamera(90*vertical + 180*horizontal);
    }
}
