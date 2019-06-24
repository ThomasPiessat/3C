using System.Collections;
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Start()
    {
        m_pauseUI.SetActive(false);
    }

    #endregion

    #region PUBLIC METHODS

    public void ToggleMenuPause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (m_pauseUI.activeSelf)
        {
            m_pauseUI.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            m_pauseUI.SetActive(true);
            Time.timeScale = 1f;
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
