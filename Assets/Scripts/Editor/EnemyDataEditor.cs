#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyData), true)]
public class EnemyDataEditor : Editor
{
    #region ATTRIBUTES



    #endregion


    #region PUBLIC METHODS
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
    #endregion

    #region PRIVATE METHODS



    #endregion
}

#endif