using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class BlendListCamController : MonoBehaviour
{
    public CinemachineBlendListCamera blendList;
    public Transform cam1;
    public Transform cam2;
    public CinemachineVirtualCameraBase vCam1;
    public CinemachineVirtualCameraBase vCam2;

    private void Awake()
    {
        blendList.m_Loop = false;
    }
    public void ShowNpc(Transform _player, Transform _npc)
    {
        cam1.transform.SetParent(this.transform);
        cam2.transform.SetParent(this.transform);

        cam1.LookAt(_npc);
        cam2.LookAt(_npc);

        blendList.m_Instructions[0].m_VirtualCamera = vCam1;
        blendList.m_Instructions[1].m_VirtualCamera = vCam2;

        blendList.m_Instructions[1].m_Blend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        blendList.m_Instructions[1].m_Blend.m_Time = 2.0f;

        blendList.m_Instructions[0].m_Hold = 1.0f;
    }
    public void ShowPlayer(Transform _player, Transform _npc)
    {
        cam2.transform.SetParent(this.transform);
        cam1.transform.SetParent(this.transform);

        cam1.LookAt(_player);
        cam2.LookAt(_player);

        blendList.m_Instructions[0].m_VirtualCamera = vCam2;
        blendList.m_Instructions[1].m_VirtualCamera = vCam1;

        blendList.m_Instructions[1].m_Blend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        blendList.m_Instructions[1].m_Blend.m_Time = 2.0f;

        blendList.m_Instructions[0].m_Hold = 1.0f;
    }
}
