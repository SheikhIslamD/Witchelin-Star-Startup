using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "Assets/Customer")]
public class Customer : ScriptableObject
{
    [Header("Customer Identifiers")]
    public string customerName;
    public Sprite customerSprite;
    public Sprite[] customerMoods = new Sprite[3];
    [Space(10)]

    [Header("Waiting Information")]
    public float patienceMax = 100;
    public float patienceRate;
}
