using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    private Vector3 offsetPos;
    private void Awake()
    {
        offsetPos = new Vector3(0f, 2f, -3f);
    }
    private void Start()
    {
        transform.SetParent(player);
        transform.localPosition = offsetPos;
    }
    private void Update()
    {
    }
}
