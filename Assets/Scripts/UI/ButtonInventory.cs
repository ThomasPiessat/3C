using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {

    }

    //Hovered
    public void OnPointerEnter(PointerEventData eventData)
    {
        //GameMediator.Instance.InventoryUI.InstantiateItemInfo();
        //GameMediator.Instance.InventoryUI.DisplayItemInfo();
    }

    //Exit Hovered
    public void OnPointerExit(PointerEventData eventData)
    {
        //GameMediator.Instance.InventoryUI.DestroyItemInfo();
    }
}