using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPepasanText", menuName = "Data/New Pepasan Text")]
[System.Serializable]
public class PepasansTextObject : ScriptableObject
{
    public List<string> sentences;
}
