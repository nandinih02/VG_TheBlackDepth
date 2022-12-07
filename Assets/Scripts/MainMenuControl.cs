using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public GameObject settingsMenu;
    public AudioMixer mainMixer;
    // Start is called before the first frame update
    void Start()
    {
        settingsMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFunction()
    {
        LivesStatic.playerLives = 3;
    LivesStatic.score = 0;
    SceneManager.LoadScene("Level1");
    }

    public void volumeFunction(bool muted)
    {
       if(muted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

    public void settingsFunction()
    {
        settingsMenu.SetActive(true);
    }

    //Settings Menu Functions
    public void backButtonFunction()
    {
        settingsMenu.SetActive(false);
    }

    public void volumeSliderFunction(float volume)
    {
        mainMixer.SetFloat("Volume", volume);
    }

    public void quitFunction()
    {
        Application.Quit();
    }
}
