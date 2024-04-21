using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundClip
{
    Hit,
    Miss,
    Help,
    AddScore,
    WorkSuccess,
    Catched,
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource musicSource, effectSource;
    [SerializeField] private AudioClip[] clips = new AudioClip[9];

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
            return;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
    public void PlaySound(SoundClip s)
    {
        PlaySound(clips[(int)s]);
    }
    public void ChangeEffectVolume(float value){
        effectSource.GetComponent<AudioSource>().volume=value;
    }
    public void ChangeMusicVolume(float value){
        musicSource.GetComponent<AudioSource>().volume=value;
    }

    //change music to a clip in AudioClip[]
    public void ChangeMusic(int index)
    {
        var _musicSource = musicSource.GetComponent<AudioSource>();
        _musicSource.clip = clips[index];
        _musicSource.Play();
        Debug.Log("Music changed to " + clips[index].name);
    }


}
