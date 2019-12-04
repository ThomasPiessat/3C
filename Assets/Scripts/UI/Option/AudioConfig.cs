﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioConfig : MonoBehaviour
{
    [SerializeField] private Dictionary<int, Slider> m_SliderList = null;
    [SerializeField] private Dictionary<int, int> m_AudioValue = null;
    [SerializeField] private Slider m_MusicSlider = null;
    [SerializeField] private Slider m_SFXSlider = null;
    [SerializeField] private AudioMixer m_AudioMixer = null;

    // Start is called before the first frame update
    void Start()
    {
        m_MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
        m_SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMusicVolume(float _Volume)
    {
        //Exposed parametters in audio mixer
        m_AudioMixer.SetFloat("MusicVolume", _Volume);
    }

    public void SetSFXVolume(float _Volume)
    {
        //Exposed parametters in audio mixer
        m_AudioMixer.SetFloat("SFXVolume", _Volume);
    }

    private void OnDisable()
    {
        float MusicVolume = 0.0f;
        float sfxVolume = 0.0f;

        m_AudioMixer.GetFloat("MusicVolume", out MusicVolume);
        m_AudioMixer.GetFloat("SFXVolume", out sfxVolume);

        PlayerPrefs.SetFloat("Music", MusicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.Save();
    }
}