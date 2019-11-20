using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreenController : MonoBehaviour
{
    [SerializeField] private GameObject m_LoadingScreenObj;
    [SerializeField] private GameObject m_Menu;
        
    [SerializeField] private Slider m_Slider;

    AsyncOperation m_Async;

    // Start is called before the first frame update
    void Start()
    {
        m_LoadingScreenObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScreen(int _LevelToLoad)
    {
        StartCoroutine(LoadingScreenControl(_LevelToLoad));
    }

    private IEnumerator LoadingScreenControl(int _LevelToLoad)
    {
        m_Menu.SetActive(false);
        m_LoadingScreenObj.SetActive(true);
        m_Async = SceneManager.LoadSceneAsync(_LevelToLoad);
        m_Async.allowSceneActivation = false;

        while(m_Async.isDone == false)
        {
            m_Slider.value = m_Async.progress;
            if(m_Async.progress == 0.9f)
            {
                m_Slider.value = 1f;
                m_Async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
