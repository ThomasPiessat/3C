using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCamera : MonoBehaviour
{
    [SerializeField] private AnimationCurve m_FadeCurve = null;
    [SerializeField] private Texture2D m_Texture = null;
    [SerializeField] private float m_Time = 0.0f;
    [SerializeField] private bool m_Done = false;
    private float m_Alpha = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetFade()
    {
        m_Done = false;
        m_Alpha = 1;
        m_Time = 0.0f;
    }

    public void DoFade()
    {
        ResetFade();
    }

    public void OnGUI()
    {
        //if (m_Done)
        //    return;
        //if (m_Texture == null)
        //    m_Texture = new Texture2D(1,1);

        //m_Texture.SetPixel(0, 0, new Color(0, 0, 0, m_Alpha));
        //m_Texture.Apply();

        //m_Time += Time.deltaTime;
        //m_Alpha = m_FadeCurve.Evaluate(m_Time);
        //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), m_Texture);
    }
}
