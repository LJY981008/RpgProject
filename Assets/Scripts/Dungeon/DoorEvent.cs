using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class DoorEvent : MonoBehaviour
{
    public CinemachineBlendListCamera blendList;
    public Transform cam1;
    public Transform cam2;
    public CinemachineFreeLook follow1;
    public CinemachineFreeLook follow2;
    public Transform teleportPos;
    public void ChangedCam(Transform _player)
    {
        follow1.m_Heading.m_Bias = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (Player.Instance.isGetKey)
            {
                case true:
                    {
                        CharacterController controller = other.GetComponent<CharacterController>();
                        controller.enabled = false;
                        other.transform.position = teleportPos.position;
                        ChangedCam(other.transform);
                        controller.enabled = true;
                        
                        
                    }
                    break;
                case false:
                    {

                    }
                    break;
            }
        }
    }
}
