using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBtnAction : MonoBehaviour, IBtnEvent
{
    public NPCAction npcAction;
    public GameObject player;

    private List<RectCheck> btnList;
    private RectCheck selectedBtn;
    private void Awake()
    {
        selectedBtn = null;
        btnList = new List<RectCheck>();
        for (int i = 0; i < transform.childCount; i++)
        {
            btnList.Add(transform.GetChild(i).GetComponent<RectCheck>());
        }
    }
    private void Start()
    {
        player = Player.Instance.gameObject;
    }
    public void OnClickDown(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        foreach(RectCheck btn in btnList)
        {
            if (btn.IsInRect(eventData.position))
            {
                selectedBtn = btn;
            }
        }
    }

    public void OnClickUp(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        RectCheck upBtn = null;
        foreach(RectCheck btn in btnList)
        {
            if (btn.IsInRect(eventData.position))
            {
                upBtn = btn;
            }
        }
        if(upBtn == selectedBtn)
        {
            switch (selectedBtn.name)
            {
                case "Btn_Attack":
                    {
                        Player.Instance.IsAttack = true;
                    }
                    break;
                case "Btn_Action":
                    {
                        if (Utill.FindNpcTr(player.transform) != null)
                        {
                            if (!QuestManager.Instance.isQuestAccept)
                            {
                                npcAction = Utill.FindNpcTr(player.transform).GetComponent<NPCAction>();
                                npcAction.StartChat();
                            }
                            else if (QuestManager.Instance.isQuestSuccess)
                            {
                                npcAction = Utill.FindNpcTr(player.transform).GetComponent<NPCAction>();
                                QuestManager.Instance.Clearquest();
                                QuestManager.Instance.isQuestSuccess = false;
                                npcAction.StartChat();
                            } 
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void OnDrag(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
    }
}
