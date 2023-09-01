using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class TypingText : MonoBehaviour
{
    MonsterType monster;
    public TextMeshProUGUI description;
    public Transform chatBackground;
    public QuestBackgroundClick backgroundClick;
    public Transform summery;
    public TextMeshProUGUI summeryText;

    [SerializeField]
    private QuestData questData;
    public QuestData QuestData { get { return questData; } }
    private int questChapter;
    private List<string> questLog;
    private float typingSpeed;
    private int typingTrigger = 0;
    public bool isClick = false;
    public bool isNextFlag = false;
    public bool isAcceptQuset = false;
    public int uid;

    private void Awake()
    {
        typingSpeed = 0.1f;
        questChapter = 1;
        questLog = new List<string>();
        SetQuestTable();
    }
    private void Update()
    {
        if (isNextFlag)
        {
            isNextFlag = false;
            typingTrigger++;
            if (typingTrigger < questLog.Count)
                Typing();
            else
            {
                questChapter++;
                chatBackground.gameObject.SetActive(false);
                summery.gameObject.SetActive(true);
                summeryText.text = questData.MonsterName + "\n" + $"0 / {questData.Num}";
            }
        }
    }

    public void Typing()
    {
        StartCoroutine(TypingLog());
    }
    IEnumerator TypingLog()
    {
        for (int j = 0; j < questLog[typingTrigger].Length; j++)
        {
            description.text = questLog[typingTrigger].Substring(0, j + 1);
            yield return new WaitForSeconds(typingSpeed);
        }
        isClick = true;
    }
    private void SetQuestTable()
    {
        for(int i = 0; i < ResourcesManager.Instance.Csv_QuestTable.Count; i++)
        {
            if(ResourcesManager.Instance.Csv_QuestTable[i]["Chapter"].ToString() == questChapter.ToString())
            {
                questLog.Add(ResourcesManager.Instance.Csv_QuestTable[i]["Content"].ToString());
                string strUid = ResourcesManager.Instance.Csv_QuestTable[i]["UID"].ToString();
                uid = int.Parse(strUid);
            }
        }
       
    }
}
