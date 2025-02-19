/*using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(MaterialFloatHandler))]
public class MaterialFloatHandlerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MaterialFloatHandler handler = (MaterialFloatHandler)target;

        EditorGUILayout.LabelField("Material Float Handler", EditorStyles.boldLabel);

        // Automatically assign material from Image component
        handler.ImageMaterial = handler.GetComponent<Image>().material;

        // Set float property name (hardcoded)
        handler.floatPropertyName = "_ClearArea";

        if (handler.ImageMaterial != null && !string.IsNullOrEmpty(handler.floatPropertyName))
        {
            if (handler.ImageMaterial.HasProperty(handler.floatPropertyName))
            {
                // Fetch the float value
                handler.floatValue = handler.ImageMaterial.GetVector(handler.floatPropertyName);
                EditorGUILayout.LabelField("Float Value", handler.floatValue.ToString());
            }
            else
            {
                EditorGUILayout.HelpBox("The material does not have the specified float property.", MessageType.Warning);
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Please assign a material and specify a float property name.", MessageType.Info);
        }

        // Add a button to set data
        if (GUILayout.Button("Set Data"))
        {
            handler.SetData(); // Call the SetData method
        }

        // Apply any changes made in the inspector
        if (GUI.changed)
        {
            EditorUtility.SetDirty(handler);
        }
    }
}

public class MaterialFloatHandler : MonoBehaviour
{
    public Material ImageMaterial;
    public string floatPropertyName;
    public Vector4 floatValue;
    public FirstTimeManager FTM;

    private void Start()
    {
        FTM = FindObjectOfType<FirstTimeManager>();
    }


    public void SetData()
    {
        if (FTM != null && FTM.tutorialSteps != null && FTM.currentStepIndex < FTM.tutorialSteps.Count)
        {
            FTM.tutorialSteps[FTM.currentStepIndex].clearArea = floatValue;
            Debug.Log($"Data set successfully! Clear Area: {floatValue}");
        }
        else
        {
            Debug.LogWarning("FTM or tutorial steps are not properly initialized.");
        }
    }
}
*/