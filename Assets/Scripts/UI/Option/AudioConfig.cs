using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioConfig : MonoBehaviour
{
    [SerializeField] private Slider m_MusicSlider = null;
    [SerializeField] private Slider m_SFXSlider = null;
    [SerializeField] private AudioMixer m_AudioMixer = null;
    [SerializeField] private TextMeshProUGUI m_PercentageMusicVol = null;
    [SerializeField] private TextMeshProUGUI m_PercentageEffectVol = null;
    [SerializeField] private Sprite m_AudioOnSprite = null;
    [SerializeField] private Sprite m_AudioOffSprite = null;
    [SerializeField] private Button m_MuteGeneral = null;
    [SerializeField] private Button m_MuteMusic = null;
    [SerializeField] private Button m_MuteEffect = null;

    private bool m_IsMusicMuted = false;
    private bool m_IsSFXMuted = false;
    private float m_VolumeBeforeMute = 0.0f;

    void Start()
    {
        m_MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
        m_SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0);
        //Ne fonctionne pas
        m_PercentageMusicVol.SetText(m_MusicSlider.value.ToString() + " %");
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

    public void MuteMusicVolume()
    {
        if (m_IsMusicMuted)
            m_AudioMixer.SetFloat("MusicVolume", m_VolumeBeforeMute);
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
