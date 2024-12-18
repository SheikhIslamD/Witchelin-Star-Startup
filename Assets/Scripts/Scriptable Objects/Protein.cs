using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Protein", menuName = "Assets/Protein")]
public class Protein : ScriptableObject
{
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
}