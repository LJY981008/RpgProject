using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    private bool isMove = false;
    public bool IsMove
    {
        set 
        { 
            isMove = value;
            animator.SetBool("isMove", isMove);
        }
    }
    private bool isFirstAttack = false;
    public bool IsFirstAttack
    {
        set { isFirstAttack = value; }
    }
    private bool isSecAttack = false;
    public bool IsSecAttack
    {
        set { isSecAttack = value; }
    }
    private bool isThrAttack = false;
    public bool IsThrAttack
    {
        set { isThrAttack = value; }
    }
    private bool isWhillWind = false;
    public bool IsWhillWind
    {
        set { isWhillWind = value; }
    }
}
