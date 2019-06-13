using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Singleton;

public class GameMediator : MySingleton<GameMediator>
{
    #region ATTRIBUTES

    private Pause m_pause = null;
    private ThirdPersonController m_thirdPersonCharacter = null;
    private FirstPersonController m_firstPersonCharcater = null;

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

    #endregion

}
