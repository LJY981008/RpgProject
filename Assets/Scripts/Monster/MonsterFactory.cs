using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    public Transform[] spawnPos;
    private int spawnTrigger = 0;
    MonsterGenerator[] monsterGenerators = null;

    void Start()
    {
        monsterGenerators = new MonsterGenerator[2];
        monsterGenerators[0] = new PatternGenerator_Goblin();
        monsterGenerators[1] = new PatternGenerator_Orc();

        for (int i = 0; i < spawnPos.Length; i++)
        {
            DoMakeTypeSkeleton();
            spawnTrigger++;
        }

    }

    public void DoMakeTypeSkeleton()
    {
        GameObject monster = Instantiate<GameObject>(ResourcesManager.Instance.Skeleton, Utill.RandomPos(spawnPos[spawnTrigger].position, 1f, 1f, "Monster"), Quaternion.identity, transform);
        monsterGenerators[0].CreateMonster(monster.GetComponent<Skeleton>());
        List<Monster> monsters = monsterGenerators[0].getMonsters();
        
    }

    /*public void DoMakeTypeOrc()
    {
        GameObject monster = Instantiate<GameObject>(ResourcesManager.Instance.Orc, Utill.RandomPos(new Vector3(-3f, 0f, 18f), 1f, 1f, "Monster"), Quaternion.identity, transform);
        monsterGenerators[1].CreateMonster(monster.GetComponent<Orc>());
        List<Monster> units = monsterGenerators[1].getMonsters();
        *//*foreach (Monster monster in monsters)
        {
            monster.Attack();
        }*//*
    }*/
}
