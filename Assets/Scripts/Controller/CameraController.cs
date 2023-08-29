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

            // ���� �� ��ġ�� ���� 
            float fPreDis = (vecPreTouchPos0 - vecPreTouchPos1).magnitude;
            // ���� �� ��ġ�� ��
            float fToucDis = (Input.touches[0].position - Input.touches[1].position).magnitude;


            // ���� �� ��ġ�� �Ÿ��� ���� �� ��ġ�� �Ÿ��� ����
            float fDis = fPreDis - fToucDis;

            // ���� �� ��ġ�� �Ÿ��� ���� �� ��ġ�� �Ÿ��� ���̸� FleldOfView�� �����մϴ�.
            defaultFieldOfView += (fDis * scrollSpeed);

            // �ִ�� 100, �ּҴ� 20���� ���̻� ���� Ȥ�� ���Ұ� ���� �ʵ��� �մϴ�.
            defaultFieldOfView = Mathf.Clamp(defaultFieldOfView, 20.0f, 100.0f);

            followCam.m_Lens.FieldOfView = defaultFieldOfView;

        }
    }
}
