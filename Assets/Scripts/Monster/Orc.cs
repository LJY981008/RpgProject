using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Orc : Monster
{
    [SerializeField]
    private CharacterData orcData;
    private float currentHp;
    public Orc()
    {
        type = MonsterType.Orc;
        hp = orcData.MaxHp;
        power = orcData.Power;
        currentHp = hp;
        Debug.Log("����");
    }
    public override float Attack()
    {
        return power;
    }

    public override void Hit(float damage)
    {
        Debug.Log("�ǰ�");
    }
}
