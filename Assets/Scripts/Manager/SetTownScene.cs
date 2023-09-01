using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SetTownScene : MonoBehaviour
{
    public GameObject player;
    public CinemachineFreeLook followCam;
    public Transform spawnPos;
    public Transform dungeonToTownPos;

    private void Awake()
    {
        followCam.Follow = Player.Instance.transform;
        followCam.LookAt = Player.Instance.transform;
        Player.Instance.transform.position = spawnPos.position;
        Player.Instance.IsSpawn = true;
    }
}
