using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class QuestTypingEvent : MonoBehaviour, IBtnEvent
{
    bool isTyping = true;

    [Header("Äù½ºÆ® ¿ä¾à UI")]
    public GameObject questMain;
    public TextMeshProUGUI textView;

    public void OnClickDown(BaseEventData _eventData)
    {
        isTyping = TypingManager.Instance.GetTouchDown();
        if (!isTyping)
        {
            transform.parent.gameObject.SetActive(false);
            questMain.SetActive(true);
            QuestManager.Instance.textView = textView;
            QuestManager.Instance.ViewQuest();
        }
    }

    public void OnClickUp(BaseEventData _eventData)
    {
        TypingManager.Instance.GetTouchUp();
    }

    public void OnDrag(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }
}
