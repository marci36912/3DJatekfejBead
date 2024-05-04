using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static TextMeshProUGUI finishedText;
    private static Canvas hud;
    private static Canvas menu;
    private static Canvas finished;

    private static bool notFinished;


    private void Start() 
    {
        hud = GameObject.Find("/UIManager/HUD").GetComponent<Canvas>();
        menu = GameObject.Find("/UIManager/PauseMenu").GetComponent<Canvas>();
        finished = GameObject.Find("/UIManager/Finished").GetComponent<Canvas>();
        finishedText = GameObject.Find("/UIManager/Finished/TimeText").GetComponent<TextMeshProUGUI>();

        Time.timeScale = 1;
        hud.enabled = true;
        menu.enabled = false;
        finished.enabled = false;

        notFinished = true;
    }
    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape) && notFinished)
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

    public static void gameEnded(string time)
    {
        notFinished = false;

        hud.enabled = false;
        menu.enabled = false;
        finished.enabled = true;

        finishedText.text = time;
    }
}
