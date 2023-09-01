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
    /// npc 상호작용 시 UI, Cam 전환
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
    /// npc 상호작용 종료 시 UI, Cam 전환
    /// </summary>
    public void EndChat()
    {
        temp = Vector3.zero;
        blend.ShowPlayer(player, transform);
        StartCoroutine(WaitTransCam());
    }
    /// <summary>
    /// Cam 전환완료 후 UI표시 및 npc 위치 원상복귀 
    /// </summary>
    /// <returns>blend 전환 시간과 일치 동일한 시간</returns>
    IEnumerator WaitTransCam()
    {
        yield return new WaitForSeconds(2f);
        playerCanvas.gameObject.SetActive(true);
        npcCanvas.gameObject.SetActive(false);
        transform.eulerAngles = defalutAngle;
    }
}
