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
    [SerializeField] private Button m_MuteMusicButton = null;
    [SerializeField] private Button m_MuteEffectButton = null;

    private string m_MusicVolumeName = "MusicVolume";
    private string m_SFXVolumeName = "SFXVolume";

    private bool m_IsMusicMuted = false;
    private bool m_IsSFXMuted = false;
    private float m_VolumeBeforeMute = 0.0f;

    void Start()
    {
        m_MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
        m_SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0);
        //Ne fonctionne pas
        m_PercentageMusicVol.SetText(m_MusicSlider.value.ToString() + " %");
<<<<<<< HEAD
        ChangeButtonSprite();
        ChangeText();
=======
>>>>>>> 8eaefca0a1012b9a01f0c9c1a51d434f04df2653
    }

    public void SetMusicVolume(float _Volume)
    {
        //Exposed parametters in audio mixer
        m_AudioMixer.SetFloat("MusicVolume", _Volume);
        ChangeText();
    }

    public void SetSFXVolume(float _Volume)
    {
        //Exposed parametters in audio mixer
        m_AudioMixer.SetFloat("SFXVolume", _Volume);
        ChangeText();
    }

<<<<<<< HEAD
    public void ToggleMute(string _AudioToMute)
    {
        float currentVolume;
        if (!m_AudioMixer.GetFloat(_AudioToMute, out currentVolume))
            return;

        if (currentVolume != -80)
        {
            m_AudioMixer.SetFloat(_AudioToMute, -80);
        }
        else
        {
            if (_AudioToMute == m_MusicVolumeName)
            {
                m_AudioMixer.SetFloat(_AudioToMute, m_MusicSlider.value);
            }
            else if (_AudioToMute == m_SFXVolumeName)
            {
                m_AudioMixer.SetFloat(_AudioToMute, m_SFXSlider.value);
            }
        }
        ChangeButtonSprite();
    }

    public void ChangeText()
    {
        float musicValue = (m_MusicSlider.value / 80 + 1) * 100;
        float SFXValue = (m_SFXSlider.value / 80 + 1) * 100;
        m_PercentageMusicVol.text = $"{string.Format("{0:0}", musicValue)}%";
        m_PercentageEffectVol.text = $"{string.Format("{0:0}", SFXValue)}%";
    }

    private void ChangeButtonSprite()
    {
        float currentVolumeMusic;
        m_AudioMixer.GetFloat(m_MusicVolumeName, out currentVolumeMusic);
        m_MuteMusicButton.GetComponent<Image>().sprite = currentVolumeMusic > -80 ? m_AudioOnSprite : m_AudioOffSprite;

        float currentVolumeSFX;
        m_AudioMixer.GetFloat(m_SFXVolumeName, out currentVolumeSFX);
        m_MuteEffectButton.GetComponent<Image>().sprite = currentVolumeSFX > -80 ? m_AudioOnSprite : m_AudioOffSprite;
=======
    public void MuteMusicVolume()
    {
        if (m_IsMusicMuted)
            m_AudioMixer.SetFloat("MusicVolume", m_VolumeBeforeMute);
>>>>>>> 8eaefca0a1012b9a01f0c9c1a51d434f04df2653
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
