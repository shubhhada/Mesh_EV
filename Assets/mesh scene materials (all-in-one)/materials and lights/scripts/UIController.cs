using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject uiPanelToShow; // Assign the UI Panel that should appear
    public Button buttonToPress;  // Assign the button

    void Start()
    {
        // Ensure the UI Panel is hidden at the start
        uiPanelToShow.SetActive(false);

        // Add a listener for the button click event
        buttonToPress.onClick.AddListener(ShowUIPanel);
    }

    void ShowUIPanel()
    {
        // Show the UI Panel when the button is clicked
        uiPanelToShow.SetActive(true);
    }
}
