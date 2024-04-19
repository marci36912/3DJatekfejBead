using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        Regex rgx = new Regex("[^a-zA-Z0-9 -]");
        name = rgx.Replace(name, "");
        GhostHolder.setName(name);
    }

    public static void setObjects(ObjectHolder show)
    {
        showCase = show;
    }
}
