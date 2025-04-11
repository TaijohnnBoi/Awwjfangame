using UnityEngine;

public class RatMover : MonoBehaviour
{
    public float speed = 2f;
    private bool isMoving = false;

    public Vector3 startPos;
    public Vector3 endPos;

    void Start()
    {
        transform.position = startPos;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, endPos) < 0.1f)
            {
                isMoving = false;
                // You can trigger a screen cover or game over here
            }
        }
    }

    public void StartRatSlide()
    {
        transform.position = startPos;
        isMoving = true;
    }

    public void PunchRat()
    {
        isMoving = false;
        gameObject.SetActive(false);
    }
}
