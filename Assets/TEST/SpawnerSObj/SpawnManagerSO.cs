using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Spawn Data", menuName = "Spawn Data")]
public class SpawnManagerSO : ScriptableObject
{
    public string PrefabName;
    public int NbPrefabToCreate;
    public Vector3[] SpawnPoints;

}
