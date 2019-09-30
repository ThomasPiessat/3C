﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Singleton;

public class GameMediator : MySingleton<GameMediator>
{
    #region ATTRIBUTES

    private static Character m_character = null;
    private static ThirdPersonController m_thirdPersonController = null;
    private static FirstPersonController m_firstPersonCharcater = null;
    private static Pause m_pause = null;
    private static InventoryUI m_inventory = null;
    private static UIManager m_uiManager = null;
    private static InputManager m_inputManager = null;

    #endregion

    #region PROPERTIES

    public Character MainCharacter
    {
        get
        {
            if (!m_character)
            {
                m_character = GameObject.FindObjectOfType<Character>();
            }

            return m_character;
        }
    }

    public ThirdPersonController TPSController
    {
        get
        {
            if (!m_thirdPersonController)
            {
                m_thirdPersonController = GameObject.FindObjectOfType<ThirdPersonController>();
            }
            return m_thirdPersonController;
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

    public InventoryUI InventoryUI
    {
        get
        {
            if (!m_inventory)
            {
                m_inventory = GameObject.FindObjectOfType<InventoryUI>();
            }

            return m_inventory;
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

    public InputManager InputManager
    {
        get
        {
            if (!m_inputManager)
            {
                m_inputManager = GameObject.FindObjectOfType<InputManager>();
            }

            return m_inputManager;
        }
    }

    #endregion

}
