using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IBtnEvent
{
    public void OnClickDown(BaseEventData _eventData);
    public void OnClickUp(BaseEventData _eventData);
    public void OnDrag(BaseEventData _eventData);
}
