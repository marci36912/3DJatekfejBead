using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedVisual : MonoBehaviour
{
    [SerializeField] private Color start;
    [SerializeField] private Color end;
    [SerializeField] private Slider speed;
    private TextMeshProUGUI speedText;
    private Image slider;

    void Start()
    {
        speedText = GetComponentInChildren<TextMeshProUGUI>();
        slider = GameObject.Find("SpeedFill").GetComponent<Image>();
    }

    public void setSpeed(float normalizedSpeed, float currectSpeed)
    {
        speed.value = normalizedSpeed;
        slider.color = Color.Lerp(start, end, normalizedSpeed);

        speedText.text = $"{(currectSpeed*3.6).ToString("0")} km/h";
    }
}
