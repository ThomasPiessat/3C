using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPClickable : MonoBehaviour
{	
	#region PRIVATE METHODS

    private void OnMouseOver()
    {
        GetComponent<Transform>().localScale = new Vector3(1.2f,1.2f,1.2f);
        GetComponent<TextMeshPro>().color = new Color(0,1,0,1);
    }

    private void OnMouseExit()
    {
        GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
        GetComponent<TextMeshPro>().color = new Color(1, 1, 1, 1);
    }

    private void OnMouseDown()
    {

    }
	 
	#endregion
}
