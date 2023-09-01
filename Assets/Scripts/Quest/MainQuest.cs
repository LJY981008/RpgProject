using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainQuest : Quest
{    
    public override void SetQuestInfo(QuestData data)
    {
        type = QuestType.MAIN;
        textSummery = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textDesc = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        questData = data;
        currentAmount = 0;
        targetAmount = questData.Num;
        targetType = questData.MonsterType;
        monsterName = questData.MonsterName;
        SaveManager.Instance.mainQuest = this;
        SaveManager.Instance.mainQuestItem = gameObject;

        textSummery.text = monsterName;
        textDesc.text = $"({currentAmount} / {targetAmount})";
    }
    public override void UpdateQuest()
    {
        currentAmount++;
        textDesc.text = $"({currentAmount} / {targetAmount})";
        if (currentAmount == targetAmount)
        {
            textSummery.text = "����Ʈ�� �Ϸ�Ǿ����ϴ�.";
            textDesc.text = string.Empty;
        }
    }
}
