using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BormalAI : MonoBehaviour
{
    public FoodClicker foodClicker;
    public Image orderBubble;
    public Sprite burgerIcon, friesIcon, sodaIcon;
    public BormalRespawnManager respawnManager;
    public GameOverManager gameOverManager;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip servedSound; // Sound when correct food is clicked
    public AudioClip wrongSound;  // Optional: sound when wrong food

    private int currentOrder;
    private bool hasBeenServed = false;

    void Start()
    {
        ShowOrder();
    }

    public void ShowOrder()
    {
        hasBeenServed = false;
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
        yield return new WaitForSeconds(7f);

        if (!hasBeenServed)
        {
            Debug.Log("Player failed to serve Bormal.");
            gameOverManager.TriggerGameOver();
        }
    }

    public void OnBormalClicked()
    {
        if (foodClicker.GetCurrentSelectedFood() == currentOrder)
        {
            hasBeenServed = true;

            if (audioSource != null && servedSound != null)
                audioSource.PlayOneShot(servedSound);

            orderBubble.gameObject.SetActive(false);
            GetComponent<Button>().interactable = false;
            gameObject.SetActive(false);

            if (respawnManager != null)
                respawnManager.RespawnBormalLater();
        }
        else
        {
            if (audioSource != null && wrongSound != null)
                audioSource.PlayOneShot(wrongSound);

            Debug.Log("Wrong order!");
        }
    }
}

