using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField]private Animator animator;
    public PlayerMovement movement;
    public CharacterController controller;
    public bool IsMove
    {
        set { animator.SetBool("isMove", value); }
    }
    public bool IsFirstAttack
    {
        set { animator.SetBool("isFirstAttack", value); }
    }
    public bool IsSecAttack
    {
        set { animator.SetBool("isSecAttack", value); }
    }
    public bool IsThrAttack
    {
        set { animator.SetBool("isThrAttack", value); }
    }
    public bool IsWhillWind
    {
        set { animator.SetBool("isWhillWind", value); }
    }
    public bool IsSpawn
    {
        set { movement.isSpawn = value; }
    }
    public bool isCamRotate = false;
    public bool isRotate = false;
}
