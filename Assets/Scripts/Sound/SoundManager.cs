using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Sound;



    [SerializeField] private AudioSource MusicAudioSource, SFXAudioSource;
    [SerializeField] private AudioClip jumpAudio, cherryAudio, gemAudio;
    void Awake()
    {
        Sound = this;
    }

    // Update is called once per frame
    public void JumpAudio()
    {
        SFXAudioSource.clip = jumpAudio;
        SFXAudioSource.Play();
    }

    public void CherryAudio()
    {
        SFXAudioSource.clip = cherryAudio;
        SFXAudioSource.Play();
    }

    public void GemAudio()
    {
        SFXAudioSource.clip = gemAudio;
        SFXAudioSource.Play();
    }
}
