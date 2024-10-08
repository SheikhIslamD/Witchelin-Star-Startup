using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerDatabase", menuName = "Assets/Databases/CustomerDatabase")]
public class CustomerDatabase : ScriptableObject
{    
    public List<Customer> anytimeCustomers;
    public List<Customer> morningCustomers;
    public List<Customer> lunchCustomers;
    public List<Customer> dinnerCustomers;
}
