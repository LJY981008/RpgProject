using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCBtnAction : MonoBehaviour, IBtnEvent
{
    public NPCAction npcAction;
    public TypingText typing;
    public QuestFactory questFactory;
    private List<RectCheck> btnList;
    private RectCheck selectedBtn = null;
    private void Awake()
    {
        selectedBtn = null;
        btnList = new List<RectCheck>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name != "Page")
            {
                btnList.Add(transform.GetChild(i).GetComponent<RectCheck>());
            }
        }
    }
    public void OnClickDown(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        foreach (RectCheck btn in btnList)
        {
            Debug.Log(btn.IsInRect(eventData.position));
            if (btn.IsInRect(eventData.position))
            {
                selectedBtn = btn;;
            }
        }
    }

    public void OnClickUp(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        RectCheck upBtn = null;
        foreach (RectCheck btn in btnList)
        {
            if (btn.IsInRect(eventData.position))
            {
                upBtn = btn;
            }
        }
        if (upBtn == selectedBtn)
        {
            switch (selectedBtn.name)
            {
                case "BtnAccept":
                    {
                        typing.isAcceptQuset = true;
                        questFactory.AddQuest(typing.uid);
                        npcAction.EndChat();
                    }
                    break;
                case "BtnRefuse":
                    {
                        npcAction.EndChat();
                    }
                    break;
                default:
                    {
                        Debug.Log("¹öÆ°¾Æ´Ô");
                    }
                    break;
            }
        }
    }
    public void OnDrag(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }
}
