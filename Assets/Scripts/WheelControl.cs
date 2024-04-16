using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    public Transform wheel;

    [HideInInspector] public WheelCollider WheelCollider;

    // Create properties for the CarControl script
    // (You should enable/disable these via the 
    // Editor Inspector window)
    public bool steerable;
    public bool motorized;

    Vector3 position;
    Quaternion rotation;

    // Start is called before the first frame update
    private void Start()
    {
        WheelCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Get the Wheel collider's world pose values and
        // use them to set the wheel model's position and rotation
        WheelCollider.GetWorldPose(out position, out rotation);
        wheel.transform.position = position;
        //Debug.Log(rotation.eulerAngles);
        //rotation.eulerAngles = new Vector3(rotation.eulerAngles.z, rotation.eulerAngles.y - 90, rotation.eulerAngles.x);
        wheel.transform.rotation = rotation;
    }
}
