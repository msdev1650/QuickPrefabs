using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PrefabListData", menuName = "QuickSelect/PrefabListData", order = 1)]
public class PrefabListData : ScriptableObject
{
    public List<string> prefabPaths = new List<string>();
}
