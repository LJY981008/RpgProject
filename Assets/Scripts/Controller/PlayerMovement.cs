using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public PlayerAnimation playerAnimation;
    private float speed = 5f;
    private float h = 0f;
    private float v = 0f;
    private float g = 20f;
    private Vector3 temp = Vector3.zero;
    private void FixedUpdate()
    {
        MovementPlayer();
    }
    private void MovementPlayer()
    {
        //이동
        Vector3 dir = GameManager.Instance.playerDir;
        h = dir.x;
        v = dir.y;
        dir = new Vector3(h, 0, v);
        dir = controller.transform.TransformDirection(dir);
        //중력
        if (!controller.isGrounded)
        {
            dir.y -= g * Time.fixedDeltaTime;
        }
        if(dir.x != 0f && dir.z != 0f)
        {
            playerAnimation.IsMove = true;
            temp = Camera.main.transform.forward;
            temp.y = 0f;
            transform.forward = temp;
            controller.Move(dir.normalized * speed * Time.fixedDeltaTime);
        }
        else
        {
            playerAnimation.IsMove = false;
        }
        
    }
}
