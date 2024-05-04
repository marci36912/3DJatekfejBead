using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedVisual : MonoBehaviour
{
    [SerializeField] private Color start;
    [SerializeField] private Color end;
    private Slider speed;
    private Image slider;

    void Start()
    {
        speed = GetComponent<Slider>();
        slider = GameObject.Find("Fill").GetComponent<Image>();
    }

    public void setSpeed(float currectSpeed)
    {
        speed.value = currectSpeed;
        slider.color = Color.Lerp(start, end, currectSpeed);
    }
}
