using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class ReadTextLog : MonoBehaviour
{
    public TextMeshProUGUI description;
    public Transform chatBackground;
    public QuestTypingEvent backgroundClick;
    public Transform summery;
    public TextMeshProUGUI summeryText;

    [SerializeField]
    private QuestData questData;
    public QuestData QuestData { get { return questData; } }
    private List<string> questLog;
    public bool isClick = false;
    public bool isNextFlag = false;
    public bool isAcceptQuset = false;
    public int uid;

    private void Awake()
    {
        questLog = new List<string>();
        SetQuestTable();
    }
    private void SetQuestTable()
    {
        /*for(int i = 0; i < ResourcesManager.Instance.Csv_QuestTable.Count; i++)
        {
            if(ResourcesManager.Instance.Csv_QuestTable[i]["Chapter"].ToString() == QuestFactory.Instance.mainChapter.ToString())
            {
                questLog.Add(ResourcesManager.Instance.Csv_QuestTable[i]["Content"].ToString());
                string strUid = ResourcesManager.Instance.Csv_QuestTable[i]["UID"].ToString();
                uid = int.Parse(strUid);
            }
        }*/
       
    }
}
