using UnityEngine;
using UnityEngine.UI;

public class KarenAI : MonoBehaviour
{
    public GameObject karenImage; // The UI Image representing Karen
    public PhoneManager phoneManager; // Reference to PhoneManager
    public float stayDuration = 999f; // She stays "forever" until dismissed
    public int requiredPresses = 4;  // Number of times space must be pressed

    private int spacePressCount = 0; // Track how many times space was pressed
    private bool isActive = false; // Is Karen currently active?

    void Start()
    {
        karenImage.SetActive(false); // Hide at start
    }

    void Update()
    {
        if (!isActive) return; // If Karen is not active, do nothing

        // Check if the player is holding space (using the PhoneManager)
        if (phoneManager.IsPhoneOut())
        {
            spacePressCount++;
            Debug.Log("Space pressed: " + spacePressCount); // Debugging how many times the space is pressed

            if (spacePressCount >= requiredPresses)
            {
                DismissKaren();
            }
        }
    }

    // This method is called to show Karen
    public void ShowKaren()
    {
        karenImage.SetActive(true);  // Display Karen's image
        spacePressCount = 0;         // Reset space press count
        isActive = true;             // Mark Karen as active
    }

    // This method dismisses Karen after the required presses
    void DismissKaren()
    {
        Debug.Log("Karen has been dismissed!");  // Debugging that Karen is dismissed
        karenImage.SetActive(false);            // Hide Karen's image
        isActive = false;                       // Mark Karen as inactive
    }
}
