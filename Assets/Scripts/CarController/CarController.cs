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
    private SpeedVisual speedVisual;

    private void OnEnable() 
    {
        car = GameObject.Find("carManager").GetComponent<CarCollection>().getCar(carEnum);
        wheels = GetComponentsInChildren<WheelControl>();
        carBody = GetComponent<Rigidbody>();

        carBody.centerOfMass += Vector3.up * -1;


        GameObject.Find("GhostRecorder").GetComponent<GhostRecorder>().setData(transform);
        speedVisual = GameObject.Find("SpeedSlider").GetComponent<SpeedVisual>();
    }

    private void Update() 
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        handBreak = Input.GetKey(KeyCode.Space);
        normalizedSpeed = carBody.velocity.magnitude / car.maxSpeed;
        speedVisual.setSpeed(normalizedSpeed);
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
                wheel.WheelCollider.steerAngle = horizontal * Mathf.Lerp(car.steeringAngle, car.steeringAngle/2.5f, normalizedSpeed);
            }
            
            if(handBreak)
            {
                if(wheel.rearWheel)
                    wheel.WheelCollider.brakeTorque = car.brakePower * 3;
                wheel.WheelCollider.motorTorque = 0;
            }
            else if(breaks)
            {
                wheel.WheelCollider.brakeTorque = car.brakePower;
                wheel.WheelCollider.motorTorque = 0;
            }
            else
            {
                if (wheel.motorized)
                {
                    wheel.WheelCollider.motorTorque = vertical * car.horsePower * torque;
                }
                wheel.WheelCollider.brakeTorque = 0;
            }

        }
    }
}
