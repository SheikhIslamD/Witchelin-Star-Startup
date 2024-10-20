using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    public Protein protein;

    [Header("Ingredient Information")]
    public string IngredientName;

    public float cookMin;
    public float cookMax;

    public int cookState = 0;

    public Sprite proteinSprite;
    [Space(10)]

    [Header("Dish Information")]
    public string dishName;
    public int cookMethod;
    public Sprite dishSprite;

    public Sprite[] resultSprites;

    public Image image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IngredientName = protein.IngredientName;
        cookMin = protein.cookMin;
        cookMax = protein.cookMax;
        cookState = protein.cookState;
        proteinSprite = protein.proteinSprite;

        dishName = protein.dishName;
        cookMethod = protein.cookMethod;
        dishSprite = protein.dishSprite;
        resultSprites = protein.resultSprites;

        image = GetComponent<Image>();
    }

    public void CookUpdate()
    {
        image.sprite = resultSprites[cookState];

    }
}
