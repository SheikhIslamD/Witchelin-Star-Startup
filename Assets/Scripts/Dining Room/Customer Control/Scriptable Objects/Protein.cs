using UnityEngine;

[CreateAssetMenu(fileName = "Protein", menuName = "Assets/Protein")]
public class Protein : ScriptableObject
{
    public string proteinName;

    public float cookMin;
    public float cookMax;

    public int cookState = 0;

    public Sprite proteinSprite;
}