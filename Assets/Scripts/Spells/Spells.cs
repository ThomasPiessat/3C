using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public GameObject m_Prefab = null;
    protected Sprite m_Icon = null;
    protected string m_Name;
    protected int m_ManaCost;
    protected float m_Cooldown;
    public bool m_IsCast = false;

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

    public void TestForButtonEditor()
    {
        if (m_Prefab)
        {
            Instantiate(m_Prefab, this.transform.position, this.transform.rotation);
            Debug.Log("BISMILA");
        }
        else
            Debug.Log("NIQUE TA MERE");
    }

}
