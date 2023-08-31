using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : Singleton<MonsterFactory>
{
    MonsterGenerator[] monsterGenerators = null;

    void Start()
    {
        monsterGenerators = new MonsterGenerator[2];
        monsterGenerators[0] = new PatternGenerator_Goblin();
        monsterGenerators[1] = new PatternGenerator_Orc();
    }

    public void DoMakeTypeGoblin()
    {
        GameObject monster = Instantiate<GameObject>(ResourcesManager.Instance.Goblin, Utill.RandomPos(new Vector3(-3f, 0f, 18f), 1f, 1f, "Monster"), Quaternion.identity, transform);
        monsterGenerators[0].CreateMonster(monster.GetComponent<Goblin>());
        List<Monster> monsters = monsterGenerators[0].getMonsters();
        /*foreach (Monster monster in monsters)
        {
            monster.Attack();
        }*/
    }

    public void DoMakeTypeOrc()
    {
        GameObject monster = Instantiate<GameObject>(ResourcesManager.Instance.Orc, Utill.RandomPos(new Vector3(-3f, 0f, 18f), 1f, 1f, "Monster"), Quaternion.identity, transform);
        monsterGenerators[1].CreateMonster(monster.GetComponent<Orc>());
        List<Monster> units = monsterGenerators[1].getMonsters();
    }
}
