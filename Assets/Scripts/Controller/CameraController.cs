using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public bool isAction = false;

    private Vector3 offsetPos;
    private void Awake()
    {
        offsetPos = new Vector3(0f, 3f, -3f);
    }
    private void Start()
    {
        transform.SetParent(player);
        transform.localPosition = offsetPos;
    }
    private void Update()
    {
    }
    public void MoveCamera()
    {

    }
    
}
