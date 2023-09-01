using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    
    
    public PlayerMovement movement;
    public CharacterController controller;
    public bool isCamRotate = false;
    public bool isRotate = false;

    [SerializeField] private Animator animator;
    private int attackCount = 0;
    private float timer = 0f;
    private float attackDelay = 1.0f;
    private float attackSpeed = 0.5f;

    [SerializeField] private CharacterData playerData;
    public HPSubject hpSubject;
    public bool isAttackFlag = false;
    private float currentHp;
    private float changedHp;
    private float power;

    public bool isGetKey = false;
    public float Power
    {
        get { return power; }
    }
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
            isAttackFlag = true;
            timer = 0f;
        }
    }
    public bool IsSecAttack
    {
        set 
        {
            attackCount++;
            animator.SetBool("isSecAttack", value);
            isAttackFlag = true;
            timer = 0f;
        }
    }
    public bool IsThrAttack
    {
        set 
        {
            attackCount++;
            animator.SetBool("isThrAttack", value);
            isAttackFlag = true;
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
        currentHp = playerData.MaxHp;
        power = playerData.Power;
        hpSubject = GameManager.Instance.HpSubject;
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

    public void Hit(float damage)
    {
        if (damage > 0)
        {
            currentHp -= damage;
            changedHp = currentHp / playerData.MaxHp;
            hpSubject.Changed(changedHp, hpSubject.MonsterHp, hpSubject.MonsterID, hpSubject.MonsterName);

            animator.Play("Hit");
            animator.SetBool("isFirAttack", false);
            animator.SetBool("isSecAttack", false);
            animator.SetBool("isThrAttack", false);
            attackCount = 0;
            timer = 0;
        }
    }
    public bool CanMove()
    {
        if (controller.enabled && attackCount == 0)
            return true;
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.CompareTag("MonsterWeapon"))
        {
            Transform monster = Utill.FindTransform(other.transform.root, "MonsterBody");
            Monster mob = monster.GetComponent<Skeleton>();
            Hit(mob.Attack());
        }

    }

}
