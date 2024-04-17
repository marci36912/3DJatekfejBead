using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public void RotateCamera(float y)
    {
        //transform.rotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
        transform.localEulerAngles = new Vector3(10 + transform.rotation.x, y, transform.rotation.z);

    }
}
