using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProteinDatabase", menuName = "Assets/Databases/ProteinDatabase")]
public class ProteinDatabase : ScriptableObject
{
    public List<Protein> beholderDishes;
    public List<Protein> slimeDishes;
    public List<Protein> cockDishes;
}
