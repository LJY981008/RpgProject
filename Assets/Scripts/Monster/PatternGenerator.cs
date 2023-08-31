using UnityEngine;

class PatternGenerator_Goblin : MonsterGenerator
{
    public override void CreateMonster(Monster goblin)
    {
        monsters.Add(goblin);

    }
}
class PatternGenerator_Orc : MonsterGenerator
{
    public override void CreateMonster(Monster orc)
    {
        monsters.Add(orc);
    }
}
