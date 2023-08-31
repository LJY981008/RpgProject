using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Orc : Monster
{
    public Orc()
    {
        type = MonsterType.Orc;
        hp = 30;
        damage = 5;
        Debug.Log("생성");
    }
    public override void Attack()
    {
        Debug.Log("공격");
    }
}
