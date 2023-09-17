using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/New ResipeSO")]
public class RecipeSO : ScriptableObject
{
    public List<ItemSO> ingregients;
    public string result;
}
