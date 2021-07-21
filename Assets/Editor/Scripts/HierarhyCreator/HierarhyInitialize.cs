using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class HierarhyInitialize : EditorWindow
{
    private static List<GameObject> _objects = new List<GameObject>();
    
    [MenuItem("Tools/Create hierarhy %#H")]
    public static void CreateHierarhy()
    {
        NewHierarhyObjects();
    }
    
    [MenuItem("Tools/Delete hierarhy %&H")]
    public static void DeleteHierarhy()
    {
        if(_objects.Count == 0) return;

        for (int i = 0; i < _objects.Count; i++)
        {
            DestroyImmediate(_objects[i]);
        }
        
        _objects.Clear();
    }

    private static void NewHierarhyObjects()
    {
        
        //Первый порядок
        var globalObject = new GameObject("[GLOBAL]");
        var renderingObject = new GameObject("[RENDERING]");
        var eventsObject = new GameObject("[EVENTS]");
        var uiObject = new GameObject("[UI]");
        
        _objects.Add(globalObject);
        _objects.Add(renderingObject);
        _objects.Add(eventsObject);
        _objects.Add(uiObject);
        
        //Второй порядок
        CreateSubobjectInGameObject(globalObject.transform);
        CreateSubobjectInGameObject(eventsObject.transform);
        CreateSubobjectInRendering(renderingObject.transform);
        
    }

    private static void CreateSubobjectInGameObject(Transform parent)
    {
        new GameObject("{Static}").transform.parent = parent;
        new GameObject("{Active}").transform.parent = parent;
    }
    
    private static void CreateSubobjectInRendering(Transform parent)
    {
        new GameObject("{Main}").transform.parent = parent;
        new GameObject("{Virtual}").transform.parent = parent;
        new GameObject("{Light}").transform.parent = parent;
    }
}
