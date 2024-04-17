using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private Transform car;
    private CameraRotator rotatePoint;
    private float horizontal, vertical;

    private void Start() 
    {
        car = GameObject.FindGameObjectWithTag("Car").transform;
        rotatePoint = GameObject.Find("Camerarotator").GetComponent<CameraRotator>();
        transform.position = new Vector3(car.position.x + offset.x, car.position.y + offset.y, car.position.z + offset.z);
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
