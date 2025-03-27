using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class UIVirtualTouchZone : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [System.Serializable]
    public class Event : UnityEvent<Vector2> { }

    [Header("Rect References")]
    public RectTransform containerRect;
    public RectTransform handleRect;

    [Header("Settings")]
    public bool clampToMagnitude;
    public float magnitudeMultiplier = 1f;
    public bool invertXOutputValue;
    public bool invertYOutputValue;
    public float movementThreshold = 0.1f; // Minimum movement threshold for rotation
    public float touchPositionTolerance = 0.1f; // Small threshold to allow minor fluctuations without triggering rotation

    private Vector2 initialDragPosition;   // Initial position when drag starts
    private Vector2 currentPointerPosition;
    private bool isDragging;

    [Header("Output")]
    public Event touchZoneOutputEvent;

    void Start()
    {
        SetupHandle();
    }

    private void OnEnable()
    {
        ResetTouchPositions();
        OutputPointerEventValue(Vector2.zero);

        if (handleRect)
        {
            SetObjectActiveState(handleRect.gameObject, false);
            UpdateHandleRectPosition(Vector2.zero);
        }
    }

    private void SetupHandle()
    {
        if (handleRect)
        {
            SetObjectActiveState(handleRect.gameObject, false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(containerRect, eventData.position, eventData.pressEventCamera, out initialDragPosition);

        if (handleRect)
        {
            SetObjectActiveState(handleRect.gameObject, true);
            UpdateHandleRectPosition(initialDragPosition);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Record the initial position for this drag event
        RectTransformUtility.ScreenPointToLocalPointInRectangle(containerRect, eventData.position, eventData.pressEventCamera, out initialDragPosition);
        isDragging = true;

        // Start invoking to update the initial drag position at regular intervals
        InvokeRepeating("UpdateInitialDragPosition", 0f, 0.1f);
        Debug.Log("DragBegin");
    }

    private void UpdateInitialDragPosition()
    {
        // Update the initial drag position to the current pointer position every 0.1 seconds
        initialDragPosition = currentPointerPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        // Get current pointer position relative to container rect
        RectTransformUtility.ScreenPointToLocalPointInRectangle(containerRect, eventData.position, eventData.pressEventCamera, out currentPointerPosition);

        // Calculate delta from the initial drag start position
        Vector2 positionDelta = currentPointerPosition - initialDragPosition;

        // Ignore small movements within the tolerance range
        if (positionDelta.magnitude < movementThreshold) return;

        // Calculate clamped position and apply any necessary inversion
        Vector2 clampedPosition = ClampValuesToMagnitude(positionDelta);
        Vector2 outputPosition = ApplyInversionFilter(clampedPosition) * magnitudeMultiplier;

        // Output the processed position for rotation
        OutputPointerEventValue(outputPosition);

        // Update handle position for visual feedback
        UpdateHandleRectPosition(currentPointerPosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Stop dragging, reset output to zero
        isDragging = false;
        OutputPointerEventValue(Vector2.zero); // Reset output

        // Stop updating initial drag position
        CancelInvoke("UpdateInitialDragPosition");

        // Reset handle position
        if (handleRect)
        {
            SetObjectActiveState(handleRect.gameObject, false);
            UpdateHandleRectPosition(Vector2.zero);
        }

        // Reset initial drag position for the next drag
        initialDragPosition = Vector2.zero;
        currentPointerPosition = Vector2.zero;
        Debug.Log("DragEnd");
    }

    private void ResetTouchPositions()
    {
        initialDragPosition = Vector2.zero;
        currentPointerPosition = Vector2.zero;
    }

    void OutputPointerEventValue(Vector2 pointerPosition)
    {
        touchZoneOutputEvent.Invoke(pointerPosition);
    }

    void UpdateHandleRectPosition(Vector2 newPosition)
    {
        if (handleRect) handleRect.anchoredPosition = newPosition;
    }

    void SetObjectActiveState(GameObject targetObject, bool newState)
    {
        targetObject.SetActive(newState);
    }

    Vector2 ClampValuesToMagnitude(Vector2 position)
    {
        return clampToMagnitude ? Vector2.ClampMagnitude(position, 1) : position;
    }

    Vector2 ApplyInversionFilter(Vector2 position)
    {
        if (invertXOutputValue) position.x = -position.x;
        if (invertYOutputValue) position.y = -position.y;
        return position;
    }
}
