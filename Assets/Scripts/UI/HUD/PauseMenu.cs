using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private static AudioSource[] audioSources;
    private float volume;

    private void OnEnable() 
    {
        if(gameObject.name == "Volume")
            StartCoroutine(getSources());
    }

    IEnumerator getSources()
    {
        yield return new WaitForEndOfFrame();
        AudioListener.volume = 1;

            volume = 0.1f;
            audioSources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            GetComponent<Slider>().value = volume;

            foreach(AudioSource source in audioSources)
            {
                source.volume = volume;
            }
    }

    public void Resume()
    {
        UIManager.changeMenu();
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeVolume(float t)
    {
        foreach(AudioSource source in audioSources)
        {
            source.volume = t;
        }
    }
}
