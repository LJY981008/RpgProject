using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Goblin : Monster
{
    public Goblin()
    {
        type = MonsterType.Goblin;
        hp = 10;
        damage = 1;
        Debug.Log("����");
    }
    public override void Attack()
    {
        Debug.Log("����");
    }
}
