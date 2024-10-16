using UnityEngine;

[CreateAssetMenu(fileName = "Dish", menuName = "Assets/Dish")]
public class Dish : ScriptableObject
{
    public string dishName;

    public Protein protein;

    public string cookMethod;
    public int dishState = 0;

    public Sprite underCooked;
    public Sprite cooked;
    public Sprite overCooked;
}
