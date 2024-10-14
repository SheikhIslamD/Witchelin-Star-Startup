using UnityEngine;

[CreateAssetMenu(fileName = "Dish", menuName = "Assets/Dish")]
public class Dish : ScriptableObject
{
    public string dishName;

    public string protein;

    public string cookMethod;

    public float cookMin;
    public float cookMax;

    public int cookState = 0;

    public Sprite underCooked;
    public Sprite cooked;
    public Sprite overCooked;
}
