using UnityEngine;
using UnityEngine.UI;

public class DynamicTutorialHighlight : MonoBehaviour
{
    [Header("References")]
    public RectTransform targetRectTransform;   // The UI element to highlight
    public Image overlay;                       // The semi-transparent overlay (full screen)
    public RectTransform hole;                  // The transparent hole UI element

    void OnEnable()
    {
        // Set the hole position and size based on the target UI element
        UpdateHoleSizeAndPosition();
    }

    // Call this method whenever you want to update the hole size and position
    public void UpdateHoleSizeAndPosition()
    {
        if (targetRectTransform == null || hole == null) return;

        // Match hole size and position to the targetRectTransform
        hole.position = targetRectTransform.position;
        hole.sizeDelta = targetRectTransform.sizeDelta;
    }

    // Optionally, you can clear the highlight when done
    public void ClearHighlight()
    {
        // Reset hole size and position (you can make it invisible as well)
        hole.sizeDelta = Vector2.zero;
        hole.position = new Vector3(0, 0, 0);
    }

    // This is for showing the overlay and ensuring the UI elements are not interactable
    public void EnableTutorialOverlay()
    {
        // Enable the overlay to block interactions outside the hole
        overlay.raycastTarget = true;
        UpdateHoleSizeAndPosition();
    }

    // Disable the overlay
    public void DisableTutorialOverlay()
    {
        // Disable the overlay so interactions can happen again
        overlay.raycastTarget = false;
    }
}
