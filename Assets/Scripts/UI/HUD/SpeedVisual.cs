using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedVisual : MonoBehaviour
{
    [SerializeField] private Color start;
    [SerializeField] private Color end;
    [SerializeField] private Slider speed;
    private Image slider;

    void Start()
    {
        slider = GameObject.Find("SpeedFill").GetComponent<Image>();
    }

    public void setSpeed(float currectSpeed)
    {
        speed.value = currectSpeed;
        slider.color = Color.Lerp(start, end, currectSpeed);
    }
}
