using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private CarEnum carEnum;
    [SerializeField] private AnimationCurve torqueCurve;
    private WheelControl[] wheels;
    private Rigidbody carBody;
    private Car car;
    private float horizontal;
    private float vertical;
    private float direction;
    private float normalizedSpeed;
    private float torque;
    private bool handBreak;
    private bool breaks;

    private void OnEnable() 
    {
        car = GameObject.Find("carManager").GetComponent<CarCollection>().getCar(carEnum);
        wheels = GetComponentsInChildren<WheelControl>();
        carBody = GetComponent<Rigidbody>();

        carBody.centerOfMass += Vector3.up * -1;


        GameObject.Find("GhostRecorder").GetComponent<GhostRecorder>().setData(transform);
    }

    private void Update() 
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        handBreak = Input.GetKey(KeyCode.Space);
        normalizedSpeed = carBody.velocity.magnitude / car.maxSpeed;
    }

    private void FixedUpdate() 
    {
        breaks = (direction > 1 && vertical < 0) || (direction < -1 && vertical > 0);

        direction = Vector3.Dot(carBody.velocity, transform.forward);
        torque = torqueCurve.Evaluate(normalizedSpeed);
        vertical = (carBody.velocity.magnitude < car.maxSpeed) ? vertical : -vertical;

        foreach (var wheel in wheels)
        {
            if (wheel.steerable)
            {
                wheel.WheelCollider.steerAngle = horizontal * (car.steeringAngle/(1+normalizedSpeed));
            }
            
            if (!handBreak && !breaks)
            {
                if (wheel.motorized)
                {
                    wheel.WheelCollider.motorTorque = vertical * car.horsePower * torque;
                }
                wheel.WheelCollider.brakeTorque = 0;
            }
            else if(handBreak)
            {
                wheel.WheelCollider.brakeTorque = car.brakePower * 3;
            }
            else if(breaks)
            {
                wheel.WheelCollider.brakeTorque = car.brakePower;
            }
        }
    }
}
