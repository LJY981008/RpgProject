using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class MonsterGenerator
{
    public List<Monster> monsters = new List<Monster>();
    public List<Monster> getMonsters()
    {
        return monsters;
    }
    public abstract void CreateMonster(Monster monster);
}
