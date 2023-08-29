using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    CinemachineFreeLook followCam;
    float scrollSpeed = 0.1f;
    float defaultFieldOfView = 40f;
    private bool isTouch = false;
    public bool IsTouch
    {
        set { isTouch = value; }
    }
    private bool isTwoTouch = false;
    public bool IsTwotouch
    {
        set { isTwoTouch = value; }
    }
    void Awake()
    {
        CinemachineCore.GetInputAxis = clickControl;
        followCam = GetComponent<CinemachineFreeLook>();
    }
    private void Update()
    {
        ZoomInOut();
    }
    public float clickControl(string axis)
    {

        if (isTouch)
        {
            Player.Instance.isCamRotate = true;
            return GameManager.Instance.camDir.normalized.y;
        }
        
        return 0;
    }
    public void ZoomInOut()
    {
        if (Input.touchCount == 2)
        {
            Vector2 vecPreTouchPos0 = Input.touches[0].position - Input.touches[0].deltaPosition;
            Vector2 vecPreTouchPos1 = Input.touches[1].position - Input.touches[1].deltaPosition;

            // 이전 두 터치의 차이 
            float fPreDis = (vecPreTouchPos0 - vecPreTouchPos1).magnitude;
            // 현재 두 터치의 차
            float fToucDis = (Input.touches[0].position - Input.touches[1].position).magnitude;


            // 이전 두 터치의 거리와 지금 두 터치의 거리의 차이
            float fDis = fPreDis - fToucDis;

            // 이전 두 터치의 거리와 지금 두 터치의 거리의 차이를 FleldOfView를 차감합니다.
            defaultFieldOfView += (fDis * scrollSpeed);

            // 최대는 100, 최소는 20으로 더이상 증가 혹은 감소가 되지 않도록 합니다.
            defaultFieldOfView = Mathf.Clamp(defaultFieldOfView, 20.0f, 100.0f);

            followCam.m_Lens.FieldOfView = defaultFieldOfView;

        }
    }
}
