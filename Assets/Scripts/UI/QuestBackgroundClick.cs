using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestBackgroundClick : MonoBehaviour, IBtnEvent
{
    public TypingText quest;
    public void OnClickDown(BaseEventData _eventData)
    {
        if (quest.isClick)
        {
            quest.isClick = false;
            quest.isNextFlag = true;
        }
    }

    public void OnClickUp(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }
}
