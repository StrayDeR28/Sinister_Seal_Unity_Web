using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCaseList", menuName = "Data/New Case List")]
[System.Serializable]
public class CaseListSO : ScriptableObject
{
    public List<GameObject> cases;
}
