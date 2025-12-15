using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject uiPanel; // Assign your UI Panel in the Inspector
    public Button showButton;  // Assign your Button in the Inspector

    void Start()
    {
        // Ensure the UI panel is hidden at the start
        uiPanel.SetActive(false);

        // Add a listener to the button's OnClick event
        showButton.onClick.AddListener(ShowUI);
    }

    void ShowUI()
    {
        uiPanel.SetActive(true); // Show UI when button is pressed
    }
}
