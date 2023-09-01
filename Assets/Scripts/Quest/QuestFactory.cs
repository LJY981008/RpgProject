using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFactory : MonoBehaviour
{
    public Quest thisQuest;
    public GameObject questItem;
    private GameObject thisItem;
    
    QuestGenerator[] questGenerators = null;
    // Start is called before the first frame update
    void Start()
    {
        questGenerators = new QuestGenerator[1];
        questGenerators[0] = new PatternGenerator_MainQuest();
    }
    public void UpdateQuest()
    {
        // null로 넘어가는 현상해결
        questItem = SaveManager.Instance.mainQuestItem;
        thisItem = Instantiate(questItem, Utill.FindTransform(transform, "QusetContent"));
        thisQuest = SaveManager.Instance.mainQuest;
        questGenerators[0].CreateQuest(thisQuest);
    }
    public void AddQuest(int uid)
    {
        switch (uid)
        {
            case (int)QuestType.MAIN:
                {
                    //메인퀘
                    thisItem = Instantiate(questItem, Utill.FindTransform(transform, "QusetContent"));
                    thisQuest = thisItem.AddComponent<MainQuest>();
                    questGenerators[0].CreateQuest(thisQuest);
                    foreach(QuestData quest in ResourcesManager.Instance.QuestDataList)
                    {
                        Debug.Log($"{quest.UID} : {uid} : {SaveManager.Instance.mainChapter} : {quest.Chapter}");
                        if (quest.UID == uid && SaveManager.Instance.mainChapter == quest.Chapter)
                        {
                            Debug.Log("이프");
                            thisQuest.SetQuestInfo(quest);
                        }
                    }
                }
                break;
            case (int)QuestType.SUB:
                {
                    //서브퀘
                }
                break;
        }
        
    }
}
