using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAction : MonoBehaviour
{
    public Transform playerCanvas;
    public Transform npcCanvas;
    public Transform player;
    public Transform camPivot;

    public delegate void Action();
    private Action action;
    private Vector3 defalutCamPos;
    private Vector3 defalutCamRot;
    private Vector3 defalutThisRot;
    private bool isAction = false;
    private void Awake()
    {
        defalutCamPos = Vector3.zero;
        defalutCamRot = Vector3.zero;
        defalutThisRot = transform.eulerAngles;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) EndChat();
    }
    public void StartChat()
    {
        defalutCamPos = Camera.main.transform.position;
        defalutCamRot = Camera.main.transform.rotation.eulerAngles;
        Camera.main.transform.position = camPivot.position;

        playerCanvas.gameObject.SetActive(false);
        npcCanvas.gameObject.SetActive(true);
        Camera.main.transform.SetParent(null);
        //action += MoveCamera;
    }
    public void EndChat()
    {
        Camera.main.transform.position = defalutCamPos;
        Camera.main.transform.eulerAngles = defalutCamRot;
        transform.eulerAngles = defalutThisRot;
        playerCanvas.gameObject.SetActive(true);
        npcCanvas.gameObject.SetActive(false);
    }

    public void MoveCamera()
    {
        Camera.main.transform.position = Vector3.MoveTowards(defalutCamPos, camPivot.position, Time.deltaTime* 3f);
        if (Camera.main.transform.position == camPivot.position) action -= MoveCamera;
    }
}
