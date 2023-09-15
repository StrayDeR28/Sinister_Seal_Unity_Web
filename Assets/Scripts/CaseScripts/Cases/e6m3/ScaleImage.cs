using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleImage : MonoBehaviour
{
    [SerializeField] private Transform transformToScale;
    [SerializeField] private float scaleFactor;
    public void ScaleTransform()
    {
        if (transformToScale != null)
        {
            if (transformToScale.GetComponent<SendTransformToScale>().GetisScaledFlag() == false)
            {
                transformToScale.localScale *= scaleFactor;
                SendMultiplyerTransform();//запоминаем нопку, которой изменяли размер
                transformToScale.GetComponent<SendTransformToScale>().SetisScaledFlag(true);
                CheckIsRightScale();
                transformToScale.GetComponent<SendTransformToScale>().SendTransform();//обновление состояния кнопок с учетом флага на объекте увелечения
            }
            else
            {
                transformToScale.localScale /= scaleFactor;
                CheckIsRightScale();
                transformToScale.GetComponent<SendTransformToScale>().SetisScaledFlag(false);
                transformToScale.GetComponent<SendTransformToScale>().SendTransform();
            }
            
        }
    }
    public void SendMultiplyerTransform()
    {
        transformToScale.GetComponent<SendTransformToScale>().Setmultiplyer(transform);
    }
    public void SetTransformToScale(Transform _transform)
    {
        transformToScale = _transform;
        HideButtons(_transform);
    }
    private void HideButtons(Transform _transform)
    {
        if (_transform.GetComponent<SendTransformToScale>().GetisScaledFlag() == false)// способ возвращать изначальный размер и делать только одно изменение размера
        {
            transform.GetComponent<Button>().interactable = true;
        }
        else
        {
            if (transform == _transform.GetComponent<SendTransformToScale>().Getmultiplyer())
            {
                transform.GetComponent<Button>().interactable = true;
            }
            else
            {
                transform.GetComponent<Button>().interactable = false;
            }
        }
    }
    private void CheckIsRightScale()
    {
        if (transformToScale.localScale.x == transformToScale.GetComponent<SendTransformToScale>().GetRightScale())
        {
            transformToScale.GetComponent<SendTransformToScale>().SetRightScaleFlag(true);
        }
        else
        {
            transformToScale.GetComponent<SendTransformToScale>().SetRightScaleFlag(false);
        }
    }
}
