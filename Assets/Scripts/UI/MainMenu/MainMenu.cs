using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static string playerName { get; private set; }
    private static ObjectHolder showCase;
    private static int index;
    private static int indexMax;

    public void startGame()
    {
        SceneManager.LoadScene("Track", LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void nextCar()
    {
        showCase.setNextCar();
    }

    public void prevCar()
    {
        showCase.setPrevCar();
    }

    public void nameChange(string name)
    {
        playerName = name;
    }

    public static void setObjects(ObjectHolder show)
    {
        showCase = show;
    }
}
