using UnityEngine;
using UnityEngine.UI;

public class FoodShooter : MonoBehaviour
{
    public GameObject burgerPrefab;
    public GameObject friesPrefab;
    public GameObject sodaPrefab;

    public Sprite burgerSprite;
    public Sprite friesSprite;
    public Sprite sodaSprite;

    public Image selectedFoodIcon; // assign in Inspector
    public Transform shootPoint;

    private GameObject currentPrefab;

    public void ShootBurger()
    {
        currentPrefab = burgerPrefab;
        selectedFoodIcon.sprite = burgerSprite;
    }

    public void ShootFries()
    {
        currentPrefab = friesPrefab;
        selectedFoodIcon.sprite = friesSprite;
    }

    public void ShootSoda()
    {
        currentPrefab = sodaPrefab;
        selectedFoodIcon.sprite = sodaSprite;
    }

    public void FireCurrentFood()
    {
        if (currentPrefab != null)
        {
            Instantiate(currentPrefab, shootPoint.position, Quaternion.identity);
        }
    }
}
