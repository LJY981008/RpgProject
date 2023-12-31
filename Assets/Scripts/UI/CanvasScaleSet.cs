using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScaleSet : MonoBehaviour
{
    public CanvasScaler scaler;
    //Default 해상도 비율
    float fixedAspectRatio = 16f / 9f;
    //현재 해상도의 비율
    float currentAspectRatio = 0f;
    private void Awake()
    {
        scaler = transform.GetComponent<CanvasScaler>();
        CanvasSet();
    }
    public void CanvasSet()
    {
        currentAspectRatio = currentAspectRatio = (float)Screen.width / (float)Screen.height;
        //현재 해상도 가로 비율이 더 길 경우
        if (currentAspectRatio > fixedAspectRatio) scaler.matchWidthOrHeight = 1;
        //현재 해상도의 세로 비율이 더 길 경우
        else if (currentAspectRatio < fixedAspectRatio) scaler.matchWidthOrHeight = 0;
    }
}
