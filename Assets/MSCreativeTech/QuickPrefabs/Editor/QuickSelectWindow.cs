using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;

//------------------| Main Class |------------------
public class QuickSelectWindow : EditorWindow
{
    private ReorderableList reorderableList;
    private Vector2 scrollPosition;
    private PrefabListData prefabListData;

    //------------------| Editor Window Methods |------------------
    [MenuItem("Window/Quick Prefabs")]
    public static void ShowWindow()
    {
        GetWindow<QuickSelectWindow>("Quick Prefabs");
    }

    private void OnEnable()
    {
        // Load the ScriptableObject or create a new one if it doesn't exist
        prefabListData = AssetDatabase.LoadAssetAtPath<PrefabListData>("Assets/MSCreativeTech/QuickPrefabs//PrefabListData.asset");
        if (prefabListData == null)
        {
            prefabListData = CreateInstance<PrefabListData>(); // Create a new instance of PrefabListData
            AssetDatabase.CreateAsset(prefabListData, "Assets/MSCreativeTech/QuickPrefabs//PrefabListData.asset"); // Create asset in the specified path
            AssetDatabase.SaveAssets(); // Save the changes to the asset database
        }

        // Initialize the reorderable list for managing prefab paths
        reorderableList = new ReorderableList(prefabListData.prefabPaths, typeof(string), true, true, true, true);

        // Draw header for the reorderable list
        reorderableList.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Quick Prefabs");
        };

        // Draw elements of the reorderable list
        reorderableList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            if (index < 0 || index >= prefabListData.prefabPaths.Count) return; // Avoid out-of-range errors

            string path = prefabListData.prefabPaths[index]; // Get the prefab path at the current index
            GameObject objInAssets = string.IsNullOrEmpty(path) ? null : AssetDatabase.LoadAssetAtPath<GameObject>(path);
            GameObject objInScene = FindGameObjectInSceneByNameOrAssetPath(path); // Find the GameObject in the scene
            GameObject displayObj = objInScene != null ? objInScene : objInAssets; // Determine which object to display

            EditorGUI.BeginChangeCheck(); // Start tracking changes in the object field
            GameObject newObj = (GameObject)EditorGUI.ObjectField(new Rect(rect.x, rect.y, rect.width - 60, EditorGUIUtility.singleLineHeight), displayObj, typeof(GameObject), true);
            if (EditorGUI.EndChangeCheck())
            {
                string newPath = newObj != null ? AssetDatabase.GetAssetPath(newObj) : "";
                prefabListData.prefabPaths[index] = string.IsNullOrEmpty(newPath) ? newObj.name : newPath;
                EditorUtility.SetDirty(prefabListData);
                AssetDatabase.SaveAssets(); // Save changes to the asset database
            }

            if (GUI.Button(new Rect(rect.x + rect.width - 50, rect.y, 50, EditorGUIUtility.singleLineHeight), "Select"))
            {
                if (objInScene != null)
                {
                    Selection.activeGameObject = objInScene;
                }
                else if (objInAssets != null)
                {
                    Selection.activeObject = objInAssets;
                }
            }
        };
    }

    //------------------| GUI Methods |------------------
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical(GUILayout.ExpandHeight(true));
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.ExpandHeight(true));

        if (reorderableList != null)
        {
            reorderableList.DoLayoutList();
        }
        else
        {
            GUILayout.Label("Reorderable list not initialized.", EditorStyles.boldLabel);
        }

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
    }

    //------------------| Utility Methods |------------------
    // Finds a GameObject in the scene by its name or its asset path, including inactive GameObjects.
    private GameObject FindGameObjectInSceneByNameOrAssetPath(string path)
    {

        GameObject objInScene = GameObject.Find(path);


        if (objInScene == null)
        {
            foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>(true))
            {

                if ((go.hideFlags & HideFlags.NotEditable) != 0 || (go.hideFlags & HideFlags.HideAndDontSave) != 0)
                    continue;


                if (go.name == path && !AssetDatabase.Contains(go))
                {
                    return go;
                }
            }
        }
        return objInScene;
    }
}
