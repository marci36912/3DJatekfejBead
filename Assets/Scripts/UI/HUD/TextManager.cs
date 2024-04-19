using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI textMesh;

    void Start()
    {
        
    }

    protected void changeText(string text)
    {
        textMesh.text = text;
    }
}
