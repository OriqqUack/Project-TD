using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PrefabPath
{
    public string name;
    public string prefabspath;
}

[CreateAssetMenu(fileName = "PrepebPath", menuName = "Config/Prepeb Path", order = 2)]
public class PrefabsPath : ScriptableObject
{
    public PrefabPath[] towerPrefabs;
    public PrefabPath[] bulletPrefab;
    public PrefabPath[] monsterPrefab;
}
