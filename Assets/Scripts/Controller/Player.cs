using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField]private Animator animator;
    public PlayerMovement movement;
    public CharacterController controller;
    public bool isCamRotate = false;
    public bool isRotate = false;

    private int attackCount = 0;
    private float timer = 0f;
    private float attackDelay = 1.0f;
    private float attackSpeed = 0.5f;
    public bool IsMove
    {
        set 
        {
            animator.SetBool("isMove", value); 
        }
    }
    public bool IsAttack
    {
        set
        {
            if (attackCount == 0 && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) IsFirstAttack = true;
            else if (attackCount == 1 && (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("FirstAttack"))) IsSecAttack = true;
            else if (attackCount == 2 && (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("SecAttack"))) IsThrAttack = true;
        }
    }
    public bool IsFirstAttack
    {
        set 
        {
            attackCount++;
            animator.SetBool("isFirAttack", value);
            timer = 0f;
        }
    }
    public bool IsSecAttack
    {
        set 
        {
            attackCount++;
            animator.SetBool("isSecAttack", value);
            timer = 0f;
        }
    }
    public bool IsThrAttack
    {
        set 
        {
            attackCount++;
            animator.SetBool("isThrAttack", value);
            timer = 0f;
        }
    }
    public bool IsWhillWind
    {
        set { animator.SetBool("isWhillWind", value); }
    }
    public bool IsSpawn
    {
        set { controller.enabled = value; }
    }
    private void Start()
    {
        animator.SetFloat("attackSpeed", attackSpeed);
    }
    private void Update()
    {
        animator.SetInteger("attackCount", attackCount);
        if(attackCount > 0)
        {
            timer += Time.deltaTime;
            if(timer > attackDelay)
            {
                animator.SetBool("isFirAttack", false);
                animator.SetBool("isSecAttack", false);
                animator.SetBool("isThrAttack", false);
                attackCount = 0;
            }
        }
    }

    public bool CanMove()
    {
        if (controller.enabled && attackCount == 0)
            return true;
        return false;
    }
}
