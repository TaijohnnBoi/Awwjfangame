using UnityEngine;
using UnityEngine.UI;

public class FoodClicker : MonoBehaviour
{
    public enum FoodType { Burger, Fries, Soda }
    private FoodType currentFood;

    [Header("Food Icons")]
    public Sprite burgerSprite;
    public Sprite friesSprite;
    public Sprite sodaSprite;

    [Header("UI")]
    public Image selectedFoodIcon; // Image showing currently selected food

    void Start()
    {
        // Default to Burger at start
        SetFood(FoodType.Burger);
    }

    public void ClickBurger()
    {
        SetFood(FoodType.Burger);
        Debug.Log("Burger selected!");
    }

    public void ClickFries()
    {
        SetFood(FoodType.Fries);
        Debug.Log("Fries selected!");
    }

    public void ClickSoda()
    {
        SetFood(FoodType.Soda);
        Debug.Log("Soda selected!");
    }

    private void SetFood(FoodType food)
    {
        currentFood = food;

        // Update selected icon
        switch (food)
        {
            case FoodType.Burger:
                selectedFoodIcon.sprite = burgerSprite;
                break;
            case FoodType.Fries:
                selectedFoodIcon.sprite = friesSprite;
                break;
            case FoodType.Soda:
                selectedFoodIcon.sprite = sodaSprite;
                break;
        }
    }

    public int GetCurrentSelectedFood()
    {
        return (int)currentFood;
    }
}

