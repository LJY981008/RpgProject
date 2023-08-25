using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    private bool isTouch = false;
    public bool IsTouch
    {
        set { isTouch = value; }
    }
    void Awake()
    {
        CinemachineCore.GetInputAxis = clickControl;
    }
    public float clickControl(string axis)
    {

        if (isTouch)
        {
            Debug.Log("hi");
            return GameManager.Instance.camDir.normalized.y;
        }

        return 0;
    }
}
