using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private List<Button> m_PlayerSpells;
    [SerializeField] private Slider m_HealthBar;
    [SerializeField] private Slider m_ManaBar;

    //[SerializeField] private Button m_PrefabButton;

    // Start is called before the first frame update
    void Start()
    {
        InitSpellsSprites();
        InitBar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void InitNbButton()
    //{
    //    int nbSpells = GameMediator.Instance.MainCharacter.m_ListSpellsTest.Count;
    //    for (int i = 0; i < nbSpells; i++)
    //    {
    //        Instantiate(m_PrefabButton);
    //    }
    //}

    #region Public METHODS

    public void ActivateSpells()
    {

    } 

    #endregion

    #region Private METHODS

    private void InitSpellsSprites()
    {
        for (int i = 0; i < m_PlayerSpells.Count; i++)
        {
            m_PlayerSpells[i].GetComponent<Image>().sprite = GameMediator.Instance.MainCharacter.m_TestSpellData.Icon;
        }
    }

    private void InitBar()
    {
        float playerHealth = GameMediator.Instance.MainCharacter.GetCurrentHealth();
        float playerMana = GameMediator.Instance.MainCharacter.GetCurrentMana();
        m_HealthBar.value = playerHealth;
        m_ManaBar.value = playerMana;
    }

    #endregion
}
