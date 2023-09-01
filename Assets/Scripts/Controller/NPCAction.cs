using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;
public class NPCAction : MonoBehaviour
{
    public BlendListCamController blend;

    public Transform playerCanvas;
    public Transform npcCanvas;
    public Transform player;
    public Quest quest;

    private Vector3 defalutAngle;
    private Vector3 temp;
    
    private void Awake()
    {
        defalutAngle = transform.eulerAngles;
        temp = Vector3.zero;
    }
    /// <summary>
    /// npc ��ȣ�ۿ� �� UI, Cam ��ȯ
    /// </summary>
    public void StartChat()
    {
        transform.LookAt(player);
        temp = transform.eulerAngles;
        temp.x = 0f;
        transform.eulerAngles = temp;

        playerCanvas.gameObject.SetActive(false);
        npcCanvas.gameObject.SetActive(true);
        blend.ShowNpc(player, transform);
        quest.Typing();
    }
    /// <summary>
    /// npc ��ȣ�ۿ� ���� �� UI, Cam ��ȯ
    /// </summary>
    public void EndChat()
    {
        temp = Vector3.zero;
        blend.ShowPlayer(player, transform);
        StartCoroutine(WaitTransCam());
    }
    /// <summary>
    /// Cam ��ȯ�Ϸ� �� UIǥ�� �� npc ��ġ ���󺹱� 
    /// </summary>
    /// <returns>blend ��ȯ �ð��� ��ġ ������ �ð�</returns>
    IEnumerator WaitTransCam()
    {
        yield return new WaitForSeconds(2f);
        playerCanvas.gameObject.SetActive(true);
        npcCanvas.gameObject.SetActive(false);
        transform.eulerAngles = defalutAngle;
    }
}
