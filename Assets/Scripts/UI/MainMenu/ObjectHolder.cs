using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    [SerializeField] private GameObject fwd;
    [SerializeField] private GameObject awd;
    [SerializeField] private GameObject rwd;

    private GameObject showCaseCar;
    public static Dictionary<CarEnum, GameObject> Cars { get; private set; }
    public static int index;
    
    void Start()
    {
        Cars = new Dictionary<CarEnum, GameObject>();
        Cars.Add(CarEnum.rwd, rwd);
        Cars.Add(CarEnum.fwd, fwd);
        Cars.Add(CarEnum.awd,awd);

        index = 0;

        showCaseCar = Instantiate(Cars.ElementAt(index).Value, transform);

        MainMenu.setObjects(gameObject.GetComponent<ObjectHolder>());
    }

    public void setNextCar()
    {
        index = index+1 >= Cars.Count ? 0 : index+1;
        Destroy(showCaseCar);
        showCaseCar = Instantiate(Cars.ElementAt(index).Value, transform);
    }

    public void setPrevCar()
    {
        index = index-1 < 0 ? Cars.Count-1 : index-1;
        Destroy(showCaseCar);
        showCaseCar = Instantiate(Cars.ElementAt(index).Value, transform);
    }
}
