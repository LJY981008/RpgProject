using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchBackgorund : MonoBehaviour, IBtnEvent
{
    private Vector3 startPos = Vector3.zero;
    private Vector3 dir = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    public void OnClickDown(BaseEventData _eventData)
    {
        PointerEventData eventdata = (PointerEventData)_eventData;
        startPos = eventdata.position;
    }

    public void OnClickUp(BaseEventData _eventData)
    {
        PointerEventData eventdata = (PointerEventData)_eventData;
        startPos = Vector3.zero;
        dir = Vector3.zero;
        rotation = Vector3.zero;
        GameManager.Instance.camDir = dir;
    }

    public void OnDrag(BaseEventData _eventData)
    {
        PointerEventData eventdata = (PointerEventData)_eventData;
        dir = eventdata.position - (Vector2)startPos;
        dir.y = -(dir.x + dir.y);
        GameManager.Instance.camDir = dir;
    }
}
