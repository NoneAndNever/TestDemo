using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public AudioMixer AudioMixer;

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        AudioMixer.SetFloat("Pitch", 0f);
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        AudioMixer.SetFloat("Pitch", 1f);
    }

    public void SetMainVolume(float value)
    {
        AudioMixer.SetFloat("MainVolume",value);
    }

    public void SetMusicVolume(float value)
    {
        AudioMixer.SetFloat("Music", value);
    }

    public void SetSFXVolume(float value)
    {
        AudioMixer.SetFloat("SFX", value);
    }
}
