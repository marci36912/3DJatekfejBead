using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CarCollection : MonoBehaviour
{
    private static List<Car> cars;

    void Awake()
    {
        if(cars == null)
        {
            cars = new List<Car>();
                             //type       hp    bp      max  steering
            cars.Add(new Car(CarEnum.rwd, 3000, 2000,    50,    35));
            cars.Add(new Car(CarEnum.awd, 900,  5000,    40,   30));
            cars.Add(new Car(CarEnum.fwd, 5000, 3500,    65,    30));
        }        
    }

    public Car getCar(CarEnum carEnum)
    {
        return cars.Find(x => x.carEnum == carEnum);
    }
}
