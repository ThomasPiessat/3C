using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private List<Button> m_PlayerSpells;

    // Start is called before the first frame update
    void Start()
    {
        InitSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitSprite()
    {
        for (int i = 0; i < m_PlayerSpells.Count; i++)
        {
            m_PlayerSpells[i].GetComponent<Image>().sprite = GameMediator.Instance.MainCharacter.m_TestSpellData.Icon;
        }
    }
}
