using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [Header("Ingredient Information")]
    public string IngredientName;

    public float cookMin;
    public float cookMax;

    public string cookMethod;
    public int cookState = 0;

    public Sprite activeSprite;
    [Space(10)]

    [Header("Dish Information")]
    public string dishName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
