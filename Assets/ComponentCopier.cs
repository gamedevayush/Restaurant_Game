using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections.Generic;

public class ComponentCopier : EditorWindow
{
    private GameObject sourceObject;
    private GameObject targetObject;

    [MenuItem("Tools/Copy Components")]
    public static void ShowWindow()
    {
        GetWindow<ComponentCopier>("Copy Components");
    }

    private void OnGUI()
    {
        GUILayout.Label("Copy Components", EditorStyles.boldLabel);

        sourceObject = (GameObject)EditorGUILayout.ObjectField("Source Object", sourceObject, typeof(GameObject), true);
        targetObject = (GameObject)EditorGUILayout.ObjectField("Target Object", targetObject, typeof(GameObject), true);

        if (GUILayout.Button("Copy Components"))
        {
            if (sourceObject != null && targetObject != null)
            {
                CopyAllComponents(sourceObject, targetObject);
            }
            else
            {
                Debug.LogWarning("Please assign both source and target objects.");
            }
        }
    }

    private void CopyAllComponents(GameObject source, GameObject target)
    {
        foreach (Component sourceComponent in source.GetComponents<Component>())
        {
            System.Type type = sourceComponent.GetType();
            Component targetComponent = target.GetComponent(type);

            if (targetComponent == null)
            {
                targetComponent = target.AddComponent(type);
            }

            CopyComponentValues(sourceComponent, targetComponent);
        }

        Debug.Log("Components copied successfully!");
    }

    private void CopyComponentValues(Component source, Component target)
    {
        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default;
        FieldInfo[] fields = source.GetType().GetFields(flags);
        foreach (FieldInfo field in fields)
        {
            if (field.IsStatic) continue; // Ignore static fields
            field.SetValue(target, field.GetValue(source));
        }

        PropertyInfo[] properties = source.GetType().GetProperties(flags);
        foreach (PropertyInfo prop in properties)
        {
            if (!prop.CanWrite || !prop.CanRead || prop.GetIndexParameters().Length > 0) continue; // Ignore non-writable or indexed properties
            try
            {
                prop.SetValue(target, prop.GetValue(source));
            }
            catch { }
        }
    }
}
