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
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void SetVolume(float value)
    {
        AudioMixer.SetFloat("MainVolume",value);
    }
}
