using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class ViewpointCycler : MonoBehaviour
{
    // Assign the XR Origin (the player camera rig) in the Inspector
    [Header("Player Reference")]
    public Transform xrOriginTransform;

    // Assign the Viewpoint GameObjects in the Inspector
    [Header("Viewpoint Targets")]
    public List<Transform> viewpoints = new List<Transform>();

    // Assign your Input Actions (A/B buttons) in the Inspector
    [Header("Controller Input Actions")]
    public InputActionProperty nextViewpointAction; // A Button
    public InputActionProperty previousViewpointAction; // B Button

    private int currentIndex = 0;

    void OnEnable()
    {
        // Subscribe to the A and B button press events
        nextViewpointAction.action.performed += MoveToNextViewpoint;
        previousViewpointAction.action.performed += MoveToPreviousViewpoint;

        // Enable the actions
        nextViewpointAction.action.Enable();
        previousViewpointAction.action.Enable();
    }

    void OnDisable()
    {
        // Unsubscribe and disable actions to prevent memory leaks
        nextViewpointAction.action.performed -= MoveToNextViewpoint;
        previousViewpointAction.action.performed -= MoveToPreviousViewpoint;

        nextViewpointAction.action.Disable();
        previousViewpointAction.action.Disable();
    }

    void Start()
    {
        if (viewpoints.Count > 0)
        {
            // Start the player at the first viewpoint
            MovePlayerToTarget(viewpoints[currentIndex]);
        }
    }

    private void MoveToNextViewpoint(InputAction.CallbackContext context)
    {
        if (viewpoints.Count == 0) return;

        // Cycle to the next index, wrapping around to 0
        currentIndex = (currentIndex + 1) % viewpoints.Count;
        MovePlayerToTarget(viewpoints[currentIndex]);
    }

    private void MoveToPreviousViewpoint(InputAction.CallbackContext context)
    {
        if (viewpoints.Count == 0) return;

        // Cycle to the previous index, wrapping around to the last index
        currentIndex = (currentIndex - 1 + viewpoints.Count) % viewpoints.Count;
        MovePlayerToTarget(viewpoints[currentIndex]);
    }

    private void MovePlayerToTarget(Transform targetViewpoint)
    {
        if (xrOriginTransform == null || targetViewpoint == null) return;

        // Get the main camera inside XR Origin
        Camera xrCamera = Camera.main;
        if (xrCamera == null) return;

        // Calculate the offset between XR Origin and Camera
        Vector3 cameraOffset = xrCamera.transform.position - xrOriginTransform.position;

        // Move XR Origin so the camera is placed exactly on the viewpoint
        xrOriginTransform.position = targetViewpoint.position - cameraOffset;

        // Apply viewpoint rotation (only yaw to avoid tilting player sideways)
        Vector3 euler = targetViewpoint.rotation.eulerAngles;
        xrOriginTransform.rotation = Quaternion.Euler(0, euler.y, 0);
    }

}