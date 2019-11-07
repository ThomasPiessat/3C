using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInventory : MonoBehaviour, ISelectHandler
{
    [SerializeField] private string m_CategoryName = "";
    [SerializeField] private TextMeshProUGUI m_CategorySelected = null;

    public void OnSelect(BaseEventData eventData)
    {
        m_CategorySelected.text = m_CategoryName;
    }

}