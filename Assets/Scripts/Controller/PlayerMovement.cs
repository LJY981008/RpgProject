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
    private void FixedUpdate()
    {
        if(Player.Instance.controller.enabled)
            MovementPlayer();
    }
    private void MovementPlayer()
    {
        //이동
        Vector3 dir = GameManager.Instance.playerDir;
        h = dir.x;
        v = dir.y;
        dir = new Vector3(h, 0, v);
        //dir = controller.transform.TransformDirection(dir);
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
            if (Player.Instance.isCamRotate)
            {
                temp = Camera.main.transform.forward;
                temp.y = 0f;
                transform.forward = temp;
                Player.Instance.isCamRotate = false;
            }
            else
            {
                Quaternion look = Quaternion.LookRotation(dir.normalized);
                transform.rotation = look;
            }
            controller.Move(transform.forward * speed * Time.fixedDeltaTime);
            //controller.Move(dir.normalized * speed * Time.fixedDeltaTime);
        }
        else
        {
            Player.Instance.IsMove = false;
        }
        
    }
}
