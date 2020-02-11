using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreateCamera : MonoBehaviour
{
    #region ATTRIBUTES



    #endregion

    #region COMPONENTS    



    #endregion

    #region MONOBEHAVIOUR METHODS

    // Start is called before the first frame update
    void Start()
    {
        new GameObject("MyCameraThing").AddComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    #region PUBLIC METHODS



    #endregion

    #region PRIVATE METHODS



    #endregion
}
