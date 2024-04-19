using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject car;
    private void Start() 
    {
        if(ObjectHolder.Cars != null)
        {
            if(ObjectHolder.Cars.Count > 0)
            {
                Instantiate(ObjectHolder.Cars.ElementAt(ObjectHolder.index).Value, transform);
            }
        }
        else
        {
            Instantiate(car, transform);
        }
    }
}
