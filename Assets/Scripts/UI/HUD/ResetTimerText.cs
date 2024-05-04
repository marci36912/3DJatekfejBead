using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResetTimerText : MonoBehaviour
{
    private TextMeshProUGUI timer;
    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
    }

    public void setTime(string text)
    {
        timer.text = text;
    }
}
