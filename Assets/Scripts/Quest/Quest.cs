using UnityEngine;
using TMPro;
public enum QuestType
{
    NONE = 0,
    MAIN = 101,
    SUB = 102
}
public abstract class Quest : MonoBehaviour
{
    protected QuestType type;
    protected MonsterType targetType;
    protected QuestData questData;
    protected string monsterName;
    protected int targetAmount;
    protected int currentAmount;
    protected TextMeshProUGUI textSummery;
    protected TextMeshProUGUI textDesc;
    public abstract void SetQuestInfo(QuestData data);
    public abstract void UpdateQuest();
}
