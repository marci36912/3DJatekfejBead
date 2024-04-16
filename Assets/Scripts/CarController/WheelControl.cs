using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    [HideInInspector] public WheelCollider WheelCollider;
    public Transform wheel;
    public bool steerable;
    public bool motorized;

    private Vector3 position;
    private Quaternion rotation;

    private void Start()
    {
        WheelCollider = GetComponent<WheelCollider>();
    }

    void LateUpdate()
    {
        WheelCollider.GetWorldPose(out position, out rotation);
        wheel.transform.position = position;
        wheel.transform.rotation = rotation;
    }
}
