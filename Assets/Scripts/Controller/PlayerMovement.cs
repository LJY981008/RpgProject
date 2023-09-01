using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public bool isSpawn = true;
    private float speed = 5f;
    private float h = 0f;
    private float v = 0f;
    private float g = 20f;
    private Vector3 temp = Vector3.zero;
    private void Start()
    {
    }
    private void FixedUpdate()
    {
        if(Player.Instance != null)
        {
            if(Player.Instance.CanMove())
                MovementPlayer();
        }
            
    }
    private void MovementPlayer()
    {
        //이동
        Vector3 dir = GameManager.Instance.playerDir;
        h = dir.x;
        v = dir.y;
        dir = new Vector3(h, 0, v);
        //중력
        if (!Utill.IsGrounded(transform))
        {
            dir.y -= g * Time.fixedDeltaTime;
            Vector3 gravity = dir;
            gravity.x = 0f;
            gravity.z = 0f;
            controller.Move(gravity.normalized * speed * Time.fixedDeltaTime);
        }
        if(dir.x != 0f && dir.z != 0f)
        {
            Player.Instance.IsMove = true;
            temp = Camera.main.transform.forward;
            temp.y = 0;
            transform.forward = temp;
            Quaternion quaternion = Quaternion.Euler(transform.eulerAngles);
            dir = quaternion * dir;
            float y = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, y, 0f);
            controller.Move(transform.forward * speed * Time.fixedDeltaTime);
        }
        else
        {
            Player.Instance.IsMove = false;
        }
        
    }
}
