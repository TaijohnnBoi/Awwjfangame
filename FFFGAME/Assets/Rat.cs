using UnityEngine;
using UnityEngine.UI;

public class Rat : MonoBehaviour
{
    public RectTransform ratTransform;
    public float speed = 200f;
    public float timeUntilCover = 3f;
    private float timer;
    private bool isWalking = false;

    public GameObject screenCover; // UI Image that covers the screen

    void Start()
    {
        ratTransform.gameObject.SetActive(false);
        screenCover.SetActive(false);
    }

    public void AppearAndWalk()
    {
        ratTransform.anchoredPosition = new Vector2(-500, Random.Range(-200, 200));
        ratTransform.gameObject.SetActive(true);
        timer = 0;
        isWalking = true;
    }

    void Update()
    {
        if (!isWalking) return;

        ratTransform.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);
        timer += Time.deltaTime;

        if (timer > timeUntilCover)
        {
            CoverScreen();
        }
    }

    public void PunchRat()
    {
        Debug.Log("Rat punched!");
        isWalking = false;
        ratTransform.gameObject.SetActive(false);
        timer = 0;
    }

    void CoverScreen()
    {
        isWalking = false;
        screenCover.SetActive(true); // full black UI Image appears
        Debug.Log("Screen covered by Rat!");
    }
}
