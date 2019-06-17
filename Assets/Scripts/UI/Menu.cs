using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	#region ATTRIBUTES
	
	
	
	#endregion

	#region PROPERTIES
	
	
	
	#endregion
	
	#region MONOBEHAVIOUR METHODS
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    #endregion

    #region PUBLIC METHODS

    public void LoadByIndex(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    #endregion
}
