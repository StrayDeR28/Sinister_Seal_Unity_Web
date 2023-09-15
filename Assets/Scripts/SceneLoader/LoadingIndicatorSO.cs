using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLoadingIndicator", menuName = "Data/New Loading Indicator")]
[System.Serializable]
public class LoadingIndicatorSO : ScriptableObject
{
    public GameObject loadingIndicator;
}
