using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void StartGame()
    {
        SceneManager.LoadScene("Spel");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void change(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
        
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);

    }
}