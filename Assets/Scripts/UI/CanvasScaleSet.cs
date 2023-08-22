using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScaleSet : MonoBehaviour
{
    public CanvasScaler scaler;
    //Default �ػ� ����
    float fixedAspectRatio = 16f / 9f;
    //���� �ػ��� ����
    float currentAspectRatio = 0f;
    private void Awake()
    {
        scaler = transform.GetComponent<CanvasScaler>();
        CanvasSet();
    }
    public void CanvasSet()
    {
        currentAspectRatio = currentAspectRatio = (float)Screen.width / (float)Screen.height;
        //���� �ػ� ���� ������ �� �� ���
        if (currentAspectRatio > fixedAspectRatio) scaler.matchWidthOrHeight = 1;
        //���� �ػ��� ���� ������ �� �� ���
        else if (currentAspectRatio < fixedAspectRatio) scaler.matchWidthOrHeight = 0;
    }
}
