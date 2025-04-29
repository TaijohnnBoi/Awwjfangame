using UnityEngine;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    public GameObject phoneUI; // Assign the phone UI image or panel in the inspector
    private bool isHoldingSpace = false;

    void Update()
    {
        // Detect if space is pressed to bring out the phone
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHoldingSpace = true;
            phoneUI.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingSpace = false;
            phoneUI.SetActive(false);
        }
    }

    public bool IsPhoneOut()
    {
        return isHoldingSpace; // Returns whether the phone is out
    }
}
