using UnityEngine;
using UnityEngine.InputSystem;

public class XRViewpointSwitcher : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionProperty aButton;   // Text view
    public InputActionProperty bButton;   // Previous view

    [Header("Viewpoints")]
    public Transform[] viewpoints;

    [Tooltip("Index of the text view in the viewpoints array")]
    public int textViewIndex = 4;

    private int currentIndex = 0;
    private Transform xrOrigin;

    void Awake()
    {
        xrOrigin = transform;
    }

    void OnEnable()
    {
        aButton.action.performed += OnATriggered;
        bButton.action.performed += OnBTriggered;

        aButton.action.Enable();
        bButton.action.Enable();
    }

    void OnDisable()
    {
        aButton.action.performed -= OnATriggered;
        bButton.action.performed -= OnBTriggered;
    }

    void OnATriggered(InputAction.CallbackContext ctx)
    {
        MoveToView(textViewIndex);
    }

    void OnBTriggered(InputAction.CallbackContext ctx)
    {
        int previous = currentIndex - 1;
        if (previous < 0) previous = viewpoints.Length - 1;
        MoveToView(previous);
    }

    void MoveToView(int index)
    {
        currentIndex = index;

        xrOrigin.position = viewpoints[index].position;
        xrOrigin.rotation = viewpoints[index].rotation;
    }
}
