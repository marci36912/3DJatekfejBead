using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] CarEnum carEnum;
    private WheelControl[] wheels;
    private Rigidbody carBody;
    private Car car;
    private float horizontal;
    private float vertical;
    private float direction;
    private bool handBreak;
    private bool breaks;

    private void Start() 
    {
        car = GameObject.Find("carManager").GetComponent<CarCollection>().getCar(carEnum);
        wheels = GetComponentsInChildren<WheelControl>();
        carBody = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        handBreak = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate() 
    {
        direction = Vector3.Dot(carBody.velocity, transform.forward);
        breaks = (direction > 0 && vertical < 0) || (direction < 0 && vertical > 0);

        foreach (var wheel in wheels)
        {
            if (wheel.steerable)
            {
                wheel.WheelCollider.steerAngle = horizontal * 10;
            }
            
            if (!handBreak && !breaks)
            {
                if (wheel.motorized)
                {
                        wheel.WheelCollider.motorTorque = vertical * 2000;
                }
                wheel.WheelCollider.brakeTorque = 0;
            }
            else if(handBreak)
            {
                wheel.WheelCollider.brakeTorque = 20000;
            }
            else if(breaks)
            {
                wheel.WheelCollider.brakeTorque = 20000;
            }
        }
    }
}
