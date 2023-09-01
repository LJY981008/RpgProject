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
        currentAmount = SaveManager.Instance.thisMainCurrent;
        targetAmount = questData.Num;
        targetType = questData.MonsterType;
        monsterName = questData.MonsterName;
        SaveManager.Instance.mainQuest = this;
        SaveManager.Instance.mainQuestItem = gameObject;

        if (SaveManager.Instance.isMainSuccess)
        {
            textSummery.text = "퀘스트가 완료되었습니다.";
            textDesc.text = string.Empty;
        }
        else
        {
            textSummery.text = monsterName;
            textDesc.text = $"({currentAmount} / {targetAmount})";
        }
    }
    public override void UpdateQuest()
    {
        currentAmount++;
        textDesc.text = $"({currentAmount} / {targetAmount})";
        if (currentAmount == targetAmount)
        {
            textSummery.text = "퀘스트가 완료되었습니다.";
            textDesc.text = string.Empty;
            SaveManager.Instance.isMainSuccess = true;
        }
        SaveManager.Instance.thisMainCurrent = currentAmount;
    }
}
