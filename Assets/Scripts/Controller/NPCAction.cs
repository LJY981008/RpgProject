using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class NPCAction : MonoBehaviour
{
    public BlendListCamController blend;


    public Transform playerCanvas;
    public Transform npcCanvas;
    public Transform player;
    public Transform camPivot;

    private Vector3 defalutAngle;
    private Vector3 temp;
    
    private void Awake()
    {
        defalutAngle = transform.eulerAngles;
        temp = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) EndChat();
    }
    public void StartChat()
    {
        transform.LookAt(player);
        temp = transform.eulerAngles;
        temp.x = 0f;
        transform.eulerAngles = temp;

        playerCanvas.gameObject.SetActive(false);
        npcCanvas.gameObject.SetActive(true);

        blend.ShowNpc();
    }
    public void EndChat()
    {
        temp = Vector3.zero;
        transform.eulerAngles = defalutAngle;
        blend.ShowPlayer();

        playerCanvas.gameObject.SetActive(true);
        npcCanvas.gameObject.SetActive(false);

        
    }

}
