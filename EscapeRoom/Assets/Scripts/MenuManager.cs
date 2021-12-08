using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public AudioManager audioManager;
    public Toggle musicToggle;

    public void toggleMusic()
    {
        if(! musicToggle.isOn){
            audioManager.Pause("MainTheme");
            return;
        }

        audioManager.Play("MainTheme");
    }
}
