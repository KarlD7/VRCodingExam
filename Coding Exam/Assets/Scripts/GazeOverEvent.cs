using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// MonoBehavior for an interactable objects. Triggers different <c>UnityEvent</c>s
/// (sets of functions) when the user is gazing at the object. The margin of error
/// for gazing (in degrees) can be adjusted to allow for more generous, comfortable
/// control.
/// </summary>
public class GazeOverEvent : MonoBehaviour
{
    /// <summary>
    /// Margin of error for a valid gaze. The number of degrees off from a direct
    /// gaze that will still be counted as looking at the object.
    /// </summary>
    /// <remarks>This should be larger for larger objects.</remarks>
    [Range(0, 360)]
    public float maximumAngleForEvent = 30f;

    public UnityEvent OnHoverBegin;
    public UnityEvent OnHover;
    public UnityEvent OnHoverEnd;
    public UnityEvent OnButtonPressedDuringHover;
    public GameObject Player;

    /// <summary>
    /// A boolean that tracks if the object is currently hovered over. Used to
    /// ensure OnHoverBegin and OnHoverEnd are only fired once per gaze start/end.
    /// </summary>
    private bool isHovering = false;
    void start()
    {
        Player = GameObject.Find("Player");
    }
    void Update()
    {
        var cameraForward = Player.transform.forward;
        var vectorToObject = transform.position - Player.transform.position;

        // Check if the angle between the camera and object is within the hover range
        var angleFromCameraToObject = Vector3.Angle(cameraForward, vectorToObject);
        if (angleFromCameraToObject <= maximumAngleForEvent)
        {
            Hovering();

            if (XRInputManager.IsButtonDown() || Input.GetMouseButtonDown(0))
            {
                ButtonPressed();
            }
        }
        else
        {
            NotHovering();
        }
    }

    private void Hovering()
    {
        if (isHovering)
        {
            OnHover.Invoke();
        }
        else
        {
            OnHoverBegin.Invoke();
            isHovering = true;
        }
    }

    private void NotHovering()
    {
        if (isHovering)
        {
            OnHoverEnd.Invoke();
            isHovering = false;
        }
    }

    private void ButtonPressed()
    {
        OnButtonPressedDuringHover.Invoke();
    }
}
