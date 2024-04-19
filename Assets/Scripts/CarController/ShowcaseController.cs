using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowcaseController : MonoBehaviour
{
    private void setShowcase(bool showcase)
    {
        GetComponent<CarController>().enabled = showcase;
        GetComponentInChildren<CameraFollow>().enabled = showcase;
        GetComponentInChildren<Camera>().enabled = showcase;
        GetComponentInChildren<AudioListener>().enabled = showcase;
    }

    private void OnEnable() 
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            setShowcase(false);
        }
        else
        {
            setShowcase(true);
        }
    }
}
