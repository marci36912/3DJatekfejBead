using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCar : MonoBehaviour
{
    [SerializeField] private Transform t;
    [SerializeField] private bool follow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(follow)
            transform.position = new Vector3(t.position.x, transform.position.y, t.position.z);
    }
}
