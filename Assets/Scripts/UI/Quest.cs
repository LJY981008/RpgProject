using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quest : MonoBehaviour
{
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

    private void Awake()
    {
        typingSpeed = 0.1f;
        questChapter = 1;
        questLog = new List<string>();
        SetQuest();
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
        StartCoroutine(TypingText());
    }
    IEnumerator TypingText()
    {
        for (int j = 0; j < questLog[typingTrigger].Length; j++)
        {
            description.text = questLog[typingTrigger].Substring(0, j + 1);
            yield return new WaitForSeconds(typingSpeed);
        }
        isClick = true;
    }
    private void SetQuest()
    {
        for(int i = 0; i < ResourcesManager.Instance.Csv_QuestTable.Count; i++)
        {
            if(ResourcesManager.Instance.Csv_QuestTable[i]["Chapter"].ToString() == questChapter.ToString())
            {
                questLog.Add(ResourcesManager.Instance.Csv_QuestTable[i]["Content"].ToString());
            }
        }
    }
}
