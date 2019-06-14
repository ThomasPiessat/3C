using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour
{
    #region ATTRIBUTES



    #endregion

    #region PROPERTIES

    [SerializeField] private GameObject m_ui = null;

    #endregion

    #region MONOBEHAVIOUR METHODS

    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Start()
    {
        m_ui.SetActive(false);
    }

    #endregion

    #region PUBLIC METHODS

    public void ToggleMenuPause()
    {
        m_ui.SetActive(true);

        if (m_ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
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
