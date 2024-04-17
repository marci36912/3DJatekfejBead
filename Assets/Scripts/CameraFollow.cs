using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private Transform car;
    private Transform rotatePoint;
    private bool backwards, left, right;

    private void Start() 
    {
        car = GameObject.FindGameObjectWithTag("Car").transform;
        rotatePoint = GameObject.Find("Camerarotator").transform;
        transform.position = new Vector3(car.position.x + offset.x, car.position.y + offset.y, car.position.z + offset.z);
    }

    private void Update()
    {
        backwards = Input.GetKey(KeyCode.DownArrow);
        left = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);

        //rotateCamera();
    }

    private void rotateCamera()
    {
        if(backwards)
        {
            rotatePoint.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if(left)
        {
            rotatePoint.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (right)
        {
            rotatePoint.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            rotatePoint.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
