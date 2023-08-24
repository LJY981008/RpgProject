using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnAction : MonoBehaviour, IBtnEvent
{
    public NPCAction npcAction;

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
            npcAction.StartChat();
            Debug.Log("상호작용");
        }
    }

    public void OnDrag(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
    }
}
