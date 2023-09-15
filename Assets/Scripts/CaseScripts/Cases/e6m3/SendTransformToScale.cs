using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendTransformToScale : MonoBehaviour
{
    [SerializeField] private float rightScale;
    [SerializeField] private bool rightScaleFlag = false;

    [SerializeField] private Transform multiplyerBar;

    [SerializeField] private bool isScaledFlag = false;
    [SerializeField] private Transform multiplyer;
    public void SendTransform()
    {
        for (int i = 0; i < multiplyerBar.childCount; i++)
        {
            multiplyerBar.GetChild(i).GetComponent<ScaleImage>().SetTransformToScale(transform);
        }
    }
    public void SetRightScaleFlag(bool _rightScaleFlag)
    {
        rightScaleFlag = _rightScaleFlag;
    }
    public bool GetRightScaleFlag() { return rightScaleFlag; }
    public float GetRightScale() { return rightScale; }

    public bool GetisScaledFlag() { return isScaledFlag; }
    public void SetisScaledFlag(bool _isScaledFlag)
    {
        isScaledFlag = _isScaledFlag;
    }

    public Transform Getmultiplyer() { return multiplyer; }
    public void Setmultiplyer(Transform _multiplyer)
    {
        multiplyer = _multiplyer;
    }
}
