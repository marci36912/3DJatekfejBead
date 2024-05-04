using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    [SerializeField] private AudioSource idle;
    [SerializeField] private AudioSource openThrottle;

    [SerializeField] private float minPitch;
    
    [SerializeField] private float maxPitch;

    private float throttle;
    
    private void Update() 
    {
        idle.pitch = throttle <= 0.025 ? 1 : 0;
        openThrottle.pitch = Mathf.Lerp(minPitch, maxPitch, throttle);
    }

    public void getThrottle(float t)
    {
        throttle = t;
    }
}
