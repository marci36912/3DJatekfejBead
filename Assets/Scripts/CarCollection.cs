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
            cars.Add(new Car("Mazda Miata NA", CarEnum.miata, DriveEnum.RWD, 2000, 2000, 20, 30));
        }        
    }

    public Car getCar(CarEnum carEnum)
    {
        return cars.Find(x => x.carEnum == carEnum);
    }
}
