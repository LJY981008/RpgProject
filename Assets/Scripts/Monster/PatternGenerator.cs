using UnityEngine;

class PatternGenerator_Skeleton : MonsterGenerator
{
    public override void CreateMonster(Monster skeleton)
    {
        monsters.Add(skeleton);

    }
}
class PatternGenerator_Orc : MonsterGenerator
{
    public override void CreateMonster(Monster orc)
    {
        monsters.Add(orc);
    }
}
class PatternGenerator_MainQuest : QuestGenerator
{
    public override void CreateQuest(Quest quest)
    {
        questList.Add(quest);
    }
}
