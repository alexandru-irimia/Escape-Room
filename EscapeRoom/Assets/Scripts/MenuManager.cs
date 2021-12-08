using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    public void goToStory()
    {
        mainMenuCanvas.SetActive(false);
        storyCanvas.SetActive(true);
    }

    public void goBackToMainMenu()
    {
        mainMenuCanvas.SetActive(true);
        storyCanvas.SetActive(false);
    }

}
