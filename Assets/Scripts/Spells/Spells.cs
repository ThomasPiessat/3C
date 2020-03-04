using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    [HideInInspector] public bool m_IsCast = false;

    protected void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        if (m_IsCast == true)
        {
            Launch();
        }
    }

    protected virtual void Launch()
    {
        transform.position += transform.forward * 40 * Time.deltaTime;
    }
}
