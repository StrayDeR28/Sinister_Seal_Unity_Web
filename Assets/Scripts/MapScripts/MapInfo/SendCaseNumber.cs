using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendCaseNumber : MonoBehaviour
{
    [SerializeField] private enum CasesEnum {
                                                e1m1, e1m2, e1m3, e1m4,
                                                e2m1, e2m2, e2m3, e2m4,
                                                e3m1, e3m2, e3m3, e3m4,
                                                e4m1, e4m2, e4m3, e4m4,
                                                e5m1, e5m2, e5m3, e5m4,
                                                e6m1, e6m2, e6m3, e6m4,
                                                e7m1, e7m2, e7m3, e7m4
                                            };
    [SerializeField] private CasesEnum caseNumber;
    public void EnumToPlayerPrefs()
    {
        int intNumber = (int)caseNumber;
        PlayerPrefs.SetString("levelIndex", intNumber.ToString());
    }
}
