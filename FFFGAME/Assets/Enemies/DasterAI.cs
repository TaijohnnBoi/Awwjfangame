using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DasterAI : MonoBehaviour
{
    public FoodClicker foodClicker;
    public Image orderBubble;
    public Sprite burgerIcon, friesIcon, sodaIcon;
    public DasterRespawnManager respawnManager;
    public GameOverManager gameOverManager;

    private int currentOrder;
    private bool isOrdering = false;
    private int ordersGiven = 0;
    private const int totalOrders = 4;

    void Start()
    {
        StartOrderCycle();
    }

    public void StartOrderCycle()
    {
        ordersGiven = 0;
        isOrdering = true;
        ShowNewOrder();
    }

    void ShowNewOrder()
    {
        currentOrder = Random.Range(0, 3); // 0 = Burger, 1 = Fries, 2 = Soda

        switch (currentOrder)
        {
            case 0: orderBubble.sprite = burgerIcon; break;
            case 1: orderBubble.sprite = friesIcon; break;
            case 2: orderBubble.sprite = sodaIcon; break;
        }

        orderBubble.gameObject.SetActive(true);
        gameObject.SetActive(true);
        GetComponent<Button>().interactable = true;

        StartCoroutine(OrderTimeout());
    }

    IEnumerator OrderTimeout()
    {
        float waitTime = 11f;
        float timer = 0f;

        while (timer < waitTime)
        {
            if (!isOrdering) yield break;
            timer += Time.deltaTime;
            yield return null;
        }

        if (isOrdering)
        {
            Debug.Log("Player failed to serve Daster in time.");
            gameOverManager.TriggerGameOver();
        }
    }

    public void OnDasterClicked()
    {
        if (!isOrdering) return;

        if (foodClicker.GetCurrentSelectedFood() == currentOrder)
        {
            ordersGiven++;

            if (ordersGiven >= totalOrders)
            {
                isOrdering = false;
                orderBubble.gameObject.SetActive(false);
                GetComponent<Button>().interactable = false;
                gameObject.SetActive(false);

                if (respawnManager != null)
                    respawnManager.RespawnDasterLater(); // you can rename or reuse the manager
            }
            else
            {
                // Next order
                ShowNewOrder();
            }
        }
        else
        {
            Debug.Log("Wrong order given to Daster.");
        }
    }
}

