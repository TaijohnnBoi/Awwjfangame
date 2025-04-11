using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TMP_Text clockText; // Link your GameClockText here in the Inspector

    private float totalTime = 360f; // 6 minutes = 360 seconds
    private string[] hours = { "12 PM", "1 PM", "2 PM", "3 PM", "4 PM", "5 PM", "6 PM" };

    private int currentHourIndex = 0;
    private float timePerHour;

    void Start()
    {
        timePerHour = totalTime / (hours.Length - 1); // 6 transitions between 7 values
        UpdateClockDisplay();
    }

    void Update()
    {
        totalTime -= Time.deltaTime;

        // Update hour based on how much time has passed
        int newHourIndex = Mathf.FloorToInt((360f - totalTime) / timePerHour);
        if (newHourIndex != currentHourIndex && newHourIndex < hours.Length)
        {
            currentHourIndex = newHourIndex;
            UpdateClockDisplay();
        }

        // Go to next scene at 6 PM (end of 6 minutes)
        if (totalTime <= 0)
        {
            // Replace with your actual scene name or index
            SceneManager.LoadScene("NextSceneName");
        }
    }

    void UpdateClockDisplay()
    {
        if (currentHourIndex < hours.Length)
            clockText.text = hours[currentHourIndex];
    }
}
