using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCombo : MonoBehaviour
{
    public bool m_IsComboComplete = false;
    public int m_NbInputPressed = 0;
    public int m_NbKeyForCombo = 3;
    public List<KeyCode> m_ComboKeyList = new List<KeyCode>();
    public KeyCode m_KeyToAdd = KeyCode.None;
    public float m_TimeBetweenKey = 4f;
    public float m_CurrentTime = 0.0f;

    combo m_combo;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (TryCombo())
        {
            StartTimer();
            if (m_CurrentTime > 0)
            {

                MakeCombo();
            }
            else
            {
                Debug.Log("Perdu");
            }


        }
    }

    public static KeyCode GetKeycodeDown()
    {
        foreach (KeyCode kc in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kc))
            {
                return kc;
            }
        }
        return KeyCode.None;
    }


    private KeyCode SetInputToAdd()
    {
        if (Input.anyKeyDown)
        {
            m_KeyToAdd = GetKeycodeDown();

            m_ComboKeyList.Add(m_KeyToAdd);
        }

        return m_KeyToAdd;
    }

    private bool TryCombo()
    {
        return true;
    }

    private void MakeCombo()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (m_combo.m_ComboList[0] == KeyCode.A)
            {
                m_IsComboComplete = false;

                m_ComboKeyList.Add(SetInputToAdd());
                m_NbInputPressed++;

                if (m_ComboKeyList.Count >= m_NbKeyForCombo)
                {
                    m_IsComboComplete = true;
                    ResetTimer();
                    Debug.Log("Ok");
                }
            }
        }
    }

    private void StartTimer()
    {
        m_CurrentTime -= Time.deltaTime;
    }

    private void ResetTimer()
    {
        m_CurrentTime = m_TimeBetweenKey;
    }

    private void SetCombo()
    {
        m_combo.m_Name = "Combo1";
        m_combo.m_NbImput = 3;
        m_combo.m_ComboList.Add(KeyCode.A);
        m_combo.m_ComboList.Add(KeyCode.A);
        m_combo.m_ComboList.Add(KeyCode.Y);
    }
}

[System.Serializable]
struct combo
{
    public string m_Name;
    public int m_NbImput;
    public List<KeyCode> m_ComboList;

}