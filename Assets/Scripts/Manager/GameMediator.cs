using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Singleton;

public class GameMediator : MySingleton<GameMediator>
{
    #region ATTRIBUTES

    private static ThirdPersonController m_thirdPersonCharacter = null;
    private static FirstPersonController m_firstPersonCharcater = null;
    private static Pause m_pause = null;
    private static UIManager m_uiManager = null;

    #endregion

    #region PROPERTIES

    public ThirdPersonController TPSCharacter
    {
        get
        {
            if (!m_thirdPersonCharacter)
            {
                m_thirdPersonCharacter = GameObject.FindObjectOfType<ThirdPersonController>();
            }
            return m_thirdPersonCharacter;
        }
    }

    public FirstPersonController FPSCharacter
    {
        get
        {
            if (!m_firstPersonCharcater)
            {
                m_firstPersonCharcater = GameObject.FindObjectOfType<FirstPersonController>();
            }
            return m_firstPersonCharcater;
        }
    }

    public Pause PauseUI
    {
        get
        {
            if (!m_pause)
            {
                m_pause = GameObject.FindObjectOfType<Pause>();
            }

            return m_pause;
        }
    }

    public UIManager UIManager
    {
        get
        {
            if (!m_uiManager)
            {
                m_uiManager = GameObject.FindObjectOfType<UIManager>();
            }

            return m_uiManager;
        }
    }

    #endregion

}
