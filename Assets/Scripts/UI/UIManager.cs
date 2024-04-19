using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static Canvas hud;
    private static Canvas menu;

    private void Start() 
    {
        hud = GameObject.Find("/UIManager/HUD").GetComponent<Canvas>();
        menu = GameObject.Find("/UIManager/PauseMenu").GetComponent<Canvas>();

        Time.timeScale = 1;
        hud.enabled = true;
        menu.enabled = false;
    }
    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            changeMenu();
        }
    }

    public static void changeMenu()
    {
        hud.enabled = !hud.enabled;
        menu.enabled = !menu.enabled;

        if(hud.enabled)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
