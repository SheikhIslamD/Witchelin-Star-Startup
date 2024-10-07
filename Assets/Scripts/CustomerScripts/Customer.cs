using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "Assets/Customer")]
public class Customer : ScriptableObject
{
    [Header("Customer Identifiers")]
    public int customerID;
    public string customerName;
    [TextArea]
    public string customerOrder;
    [Space(10)]

    [Header("Order Informaion")]
    public int protein1;
    public int protein2;
    public int[] addOns = new int[10];
    [Space(10)]

    [Header("Waiting Information")]
    public float patienceMax = 100;
    public float patienceRate;
}
