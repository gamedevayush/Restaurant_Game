using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; // Required for UnityEvents
using TMPro; // Required for UnityEvents

public class FirstTimeManager : MonoBehaviour
{
    [System.Serializable]
    public class TutorialStep
    {
        public string stepDescription;             // Description of the step (for the UI TextBox)
        public List<GameObject> enableObjects;     // List of objects to enable in this step
        public List<GameObject> disableObjects;    // List of objects to disable in this step
        public Transform highlightObject;          // Object to highlight (like a button or UI element)
        public bool requiresNextButton;            // Does this step need a "Next" button to proceed?
        public UnityEvent customAction;            // Custom action that can be triggered during this step
    }

    public List<TutorialStep> tutorialSteps;       // List of tutorial steps
    public Button nextButton;                     // Reference to the Next button
    public GameObject arrowIndicator;             // Arrow or object used to highlight UI elements
    public Transform arrowDefaultPosition;        // Default position of the arrow (if no object to highlight)
    public TextManager tm;
    public int currentStepIndex = 0;


    void Start()
    {
        StartTutorial();
    }

    public void StartTutorial()
    {
        currentStepIndex = 0; // Start at the first step
        nextButton.onClick.AddListener(OnNextButtonClicked); // Add listener to the Next button
        ShowStep(currentStepIndex); // Show the first step
    }

    public void ShowStep(int stepIndex)
    {
        if (stepIndex < tutorialSteps.Count)
        {
            TutorialStep step = tutorialSteps[stepIndex];

            // Update tutorial text
            tm.CaptionTextHandler("Tutorial", step.stepDescription, Color.cyan, false);

            // Enable or disable objects for this step
            foreach (GameObject obj in step.enableObjects)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in step.disableObjects)
            {
                obj.SetActive(false);
            }

            // Highlight the object if there is one
            if (step.highlightObject != null)
            {
                HighlightObject(step.highlightObject);
            }
            else
            {
                RemoveHighlight();
            }

            // Trigger custom actions if any
            if (step.customAction != null)
            {
                step.customAction.Invoke();
            }

            // Handle Next button visibility
            nextButton.gameObject.SetActive(step.requiresNextButton);
        }
        else
        {
            EndTutorial(); // End the tutorial if all steps are completed
        }
    }

    // This method will be called when the Next button is clicked
    public void OnNextButtonClicked()
    {
        currentStepIndex++;
        ShowStep(currentStepIndex);
    }

    // Highlight the specified object (move the arrow to the object's position)
    public void HighlightObject(Transform objToHighlight)
    {
        arrowIndicator.SetActive(true);
        arrowIndicator.transform.position = objToHighlight.position;
    }

    // Remove the highlight (hide the arrow)
    public void RemoveHighlight()
    {
        arrowIndicator.transform.position = arrowDefaultPosition.position;
        arrowIndicator.SetActive(false);
    }

    // End the tutorial by disabling the tutorial elements
    public void EndTutorial()
    {
        nextButton.gameObject.SetActive(false);
        arrowIndicator.SetActive(false);
    }

    public void ValidateAndCall(int value)
    {
        if (value == currentStepIndex)
        {
            OnNextButtonClicked();
        }
    }
}
