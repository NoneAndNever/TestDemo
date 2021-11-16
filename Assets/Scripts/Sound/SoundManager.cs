using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Sound;

    public AudioSource audioSource;
    [SerializeField]
    private AudioClip jumpAudio, cherryAudio, gemAudio;
    void Awake()
    {
        Sound = this;
    }

    // Update is called once per frame
    public void JumpAudio()
    {
        audioSource.clip = jumpAudio;
        audioSource.Play();
    }

    public void CherryAudio()
    {
        audioSource.clip = cherryAudio;
        audioSource.Play();
    }

    public void GemAudio()
    {
        audioSource.clip = gemAudio;
        audioSource.Play();
    }
}
