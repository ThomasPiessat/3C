using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    protected GameObject m_Prefab = null;
    public Sprite m_Icon = null;
    protected string m_Name;
    protected int m_ManaCost;
    protected float m_Cooldown;
    public bool m_IsCast = false;

    public Item m_test;

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
        for (int i = 0; i < transform.childCount; i++)
        {
#if UNITY_EDITOR
            DestroyImmediate(transform.GetChild(i).gameObject);
#else
            Destroy(transform.GetChild(i).gameObject);
#endif
            i--;
        }

        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.SetParent(transform);
        go.transform.localScale = new Vector3(Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10));

        if (m_Prefab)
        {
            Instantiate(m_Prefab, this.transform.position, this.transform.rotation);
            Debug.Log("BISMILA");
        }
        else
            Debug.Log("NIQUE TA MERE");
    }

}
