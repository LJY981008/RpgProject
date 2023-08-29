using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IBtnEvent
{
    public void OnClickDown(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnClickUp(BaseEventData _eventData)
    {
        GameManager.Instance.LoadScene("DungeonScene");
    }

    public void OnDrag(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }
}
