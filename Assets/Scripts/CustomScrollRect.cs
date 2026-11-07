using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomScrollRect : ScrollRect
{
    [Header("Individual Sensitivity Modifiers")]
    [Tooltip("Multiplier for horizontal scrolling (X axis). Default is 1.")]
    public float horizontalSensitivityMultiplier = 1.0f;
    
    [Tooltip("Multiplier for vertical scrolling (Y axis). Default is 1.")]
    public float verticalSensitivityMultiplier = 1.0f;

    public override void OnScroll(PointerEventData data)
    {
        if (!IsActive()) return;

        // Save the original scroll delta
        Vector2 originalDelta = data.scrollDelta;

        // Apply individual multipliers to the X and Y axes
        Vector2 modifiedDelta = originalDelta;
        modifiedDelta.x *= horizontalSensitivityMultiplier;
        modifiedDelta.y *= verticalSensitivityMultiplier;

        // Temporarily swap the delta, run the base logic, and restore it
        data.scrollDelta = modifiedDelta;
        base.OnScroll(data);
        data.scrollDelta = originalDelta; 
    }
}
