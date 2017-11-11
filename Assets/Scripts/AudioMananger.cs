using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioMananger : MonoBehaviour
{
    public static AudioMananger instance;

    public AudioMixerGroup explosions;
    public AudioMixerGroup shoot;
    public AudioMixerGroup boss;
    public AudioMixerGroup piumpium;

    private void wake()
    {
        instance = this;
    }

    public void Explosions(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = explosions;
        source.clip = clip;
        source.Play();
    }

    public void Shoot(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = shoot;
        source.clip = clip;
        source.Play();
    }

    public void Boss(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = boss;
        source.clip = clip;
        source.Play();
    }

    public void PiumPium(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = piumpium;
        source.clip = clip;
        source.Play();
    }

}
