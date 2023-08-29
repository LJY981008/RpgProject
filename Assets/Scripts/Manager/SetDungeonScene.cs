using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SetDungeonScene : MonoBehaviour
{
    public CinemachineFreeLook followCam;
    public GameObject startPivot;
    private Vector3 startPos;
    private Vector3 startRot;
    private GameObject player;
    private void Awake()
    {
        startPos = Utill.RandomPos(startPivot.transform.position, 2f, 1f);
        startPos.y = 1f;
        startRot = new Vector3(0f, -90f, 0f);
    }
    private void Start()
    {
        player = Player.Instance.gameObject;
        player.transform.position = startPos;
        player.transform.eulerAngles = startRot;
        Player.Instance.IsSpawn = true;
        followCam.LookAt = player.transform;
        followCam.Follow = player.transform;
        Camera.main.transform.forward = player.transform.forward;
    }
    
}
