﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour
{
    #region ATTRIBUTES



    #endregion

    #region PROPERTIES

    [SerializeField] private GameObject m_pauseUI = null;

    #endregion

    #region MONOBEHAVIOUR METHODS

    private void Awake()
    {

    }

    void Start()
    {
        m_pauseUI.SetActive(false);
    }

    #endregion

    #region PUBLIC METHODS

    public void ToggleMenuPause()
    {
        if (m_pauseUI.activeSelf)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            m_pauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            m_pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ReturnToGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        m_pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    #endregion
}
