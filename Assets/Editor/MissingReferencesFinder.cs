using UnityEngine;
using UnityEditor;
using System.Reflection;

public class MissingReferencesFinder : EditorWindow
{
    [MenuItem("Tools/Find Missing References")]
    public static void ShowWindow()
    {
        GetWindow<MissingReferencesFinder>("Missing References Finder");
    }

    private void OnGUI()
    {
        GUILayout.Label("Find Missing References in Scene", EditorStyles.boldLabel);

        if (GUILayout.Button("Find Missing References"))
        {
            FindMissingReferences();
        }
    }

    private void FindMissingReferences()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>(true);

        foreach (GameObject obj in allObjects)
        {
            foreach (Component component in obj.GetComponents<Component>())
            {
                if (component == null) continue;

                SerializedObject so = new SerializedObject(component);
                SerializedProperty prop = so.GetIterator();
                while (prop.NextVisible(true))
                {
                    if (prop.propertyType == SerializedPropertyType.ObjectReference && prop.objectReferenceValue == null && prop.objectReferenceInstanceIDValue != 0)
                    {
                        Debug.LogWarning($"Missing reference found in GameObject: {obj.name}, Component: {component.GetType().Name}, Property: {prop.name}", obj);
                    }
                }
            }
        }
        Debug.Log("Missing reference check completed.");
    }
}
