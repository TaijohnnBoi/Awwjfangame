using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public GameObject phoneUI; // Assign the phone panel here

    private bool isPhoneVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePhone();
        }
    }

    void TogglePhone()
    {
        isPhoneVisible = !isPhoneVisible;
        phoneUI.SetActive(isPhoneVisible);
    }
}
