using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
enum QuestType
{
    NONE = 100,
    MAIN,
    SUB
}
public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public Transform scrollView;
    public GameObject questItem;
    private GameObject currentItem;
    private TextMeshProUGUI summeryText;
    private TextMeshProUGUI numText;

    [HideInInspector]
    public TextMeshProUGUI textView;
    [HideInInspector]
    public QuestData currentData = null;
    

    private List<Dictionary<string, object>> questTable;
    private List<Dictionary<string, object>> mainQuestTable;
    private List<Dictionary<string, object>> subQuestTable;

    public int currentQuestUid = 0;
    public int currentQuestType = 0;
    public int mainQuestProgreeUID = 1;
    public int currentMonsterCount = -1;
    public bool isQuestAccept = false;
    public bool isQuestSuccess = false; 
    private string questTargetSummery = string.Empty;
    private string questTargetNum = string.Empty;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Start()
    {
        questTable = ResourcesManager.Instance.Csv_QuestTable;
        mainQuestTable = new List<Dictionary<string, object>>();
        subQuestTable = new List<Dictionary<string, object>>();

        SortQuest();
    }
    public void Clearquest()
    {
        currentMonsterCount = -1;
        currentQuestType = 0;
        currentQuestUid = 0;
        questTargetSummery = string.Empty;
        questTargetNum = string.Empty;
        Destroy(currentItem);
    }
    private void SortQuest()
    {
        foreach(Dictionary<string, object> quest in questTable)
        {
            switch (quest["Type"])
            {
                case (int)QuestType.MAIN:
                    {
                        mainQuestTable.Add(quest);
                    }
                    break;
                case (int)QuestType.SUB:
                    {
                        subQuestTable.Add(quest);
                    }
                    break;
                default:
                    break;
            }
        }
    }
    public void UpdateQuest(int type)
    {
        if (type == (int)currentData.MonsterType)
        {
            currentMonsterCount++;
            if (currentMonsterCount < currentData.Num)
            {
                questTargetNum = $"{currentMonsterCount} / {currentData.Num}";
                numText.text = questTargetNum;
            }
            else
            {
                questTargetNum = "퀘스트가 완료되었습니다";
                isQuestSuccess = true;
                mainQuestProgreeUID++;
                summeryText.text = questTargetNum;
                numText.text = "";
            }
        }
    }
    public void SetViewItem()
    {
        if (currentMonsterCount > -1)
        {
            if (currentData != null)
            {
                if (currentMonsterCount >= currentData.Num)
                {
                    questTargetSummery = "퀘스트가 완료되었습니다";
                    questTargetNum = "";
                }
                else
                {
                    questTargetSummery = $"{currentData.MonsterName} 처치";
                    questTargetNum = $"{currentMonsterCount} / {currentData.Num}";
                }
                currentItem = Instantiate(questItem, Utill.FindTransform(scrollView, "QuestContent"));
                summeryText = currentItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                numText = currentItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                currentMonsterCount = 0;
                summeryText.text = questTargetSummery;
                numText.text = questTargetNum;
            }
        }
    }
    public void ViewQuest()
    {
        List<QuestData> dataList = ResourcesManager.Instance.QuestDataList;
        foreach(QuestData data in dataList)
        {
            if(data.Type == currentQuestType && data.Uid == mainQuestProgreeUID)
            {
                currentData = data;
            }
        }
        textView.text = currentData.SummeryName;
    }
    public string[] SearchQuest(int _npcUid, int _questType)
    {
        List<string> text = new List<string>();
        switch (_questType)
        {
            case (int)QuestType.MAIN:
                {
                    foreach(Dictionary<string, object> obj in mainQuestTable)
                    {
                        Debug.Log(obj["UID"].ToString());
                        if(obj["Npc"].ToString() == _npcUid.ToString() && obj["UID"].ToString() == mainQuestProgreeUID.ToString())
                        {
                            text.Add(obj["Content"].ToString());
                            currentQuestType = _questType;
                            currentQuestUid = mainQuestProgreeUID;
                        }
                    }
                }
                break;
            case (int)QuestType.SUB:
                {

                }
                break;
        }
        return text.ToArray();
    }
}
