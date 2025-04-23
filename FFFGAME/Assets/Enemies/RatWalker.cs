using UnityEngine;

public class RatWalker : MonoBehaviour
{
    public float speed = 200f;
    public float bopAmount = 10f;         // how high the bop is
    public float bopSpeed = 5f;           // how fast the bop is
    private RectTransform rt;
    public RatManager manager;
    public GameObject ratBlockImage;

    private Vector2 originalPosition;
    private float timeAlive = 0f;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        originalPosition = rt.anchoredPosition;
    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
            // Move left
            rt.anchoredPosition += Vector2.left * speed * Time.deltaTime;

            // Bop effect
            timeAlive += Time.deltaTime;
            float bopOffset = Mathf.Sin(timeAlive * bopSpeed) * bopAmount;
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, originalPosition.y + bopOffset);

            // Off-screen trigger
            if (rt.anchoredPosition.x < -1000)
            {
                Debug.Log("Rat blocked your screen!");
                gameObject.SetActive(false);
                ratBlockImage.SetActive(true);
            }
        }
    }

    public void PunchRat()
    {
        Debug.Log("Rat got punched!");
        gameObject.SetActive(false);
        manager.StartRespawn();
    }
}
