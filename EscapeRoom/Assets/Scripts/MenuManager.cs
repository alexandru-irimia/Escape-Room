using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public AudioManager audioManager;
    public Toggle musicToggle;

    public GameObject mainMenuCanvas;
    public GameObject storyCanvas;

    public void toggleMusic()
    {
        if(! musicToggle.isOn){
            audioManager.Pause("MainTheme");
            return;
        }

        audioManager.Play("MainTheme");
    }

    public void setVolume(float volume)
    {
        audioManager.setVolume("MainTheme", volume);
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
