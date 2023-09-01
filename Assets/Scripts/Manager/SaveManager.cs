using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    public int mainChapter;
    public int thisUid;
    public Quest mainQuest;
    public GameObject mainQuestItem;
    public List<GameObject> subQuestItemList;
    private void Start()
    {
        mainQuest = null;
        mainQuestItem = null;
        mainChapter = 1;

        subQuestItemList = new List<GameObject>();
    }
}
