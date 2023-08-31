using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Goblin : Monster
{
    public Goblin()
    {
        type = MonsterType.Goblin;
        name = "Goblin";
        hp = 10;
        damage = 1;
        Debug.Log(this.name + "����");
    }
    public override void Attack()
    {
        Debug.Log("����");
    }
}
