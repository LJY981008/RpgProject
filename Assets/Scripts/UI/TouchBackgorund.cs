using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchBackgorund : MonoBehaviour, IBtnEvent
{
    private Vector3 startPos = Vector3.zero;
    private Vector3 dir = Vector3.zero;
    private int touchMode = 0;
    public CameraController camControl;

    public void OnClickDown(BaseEventData _eventData)
    {
        PointerEventData eventdata = (PointerEventData)_eventData;
        startPos = eventdata.position;
        touchMode = Input.touchCount;
        if (touchMode == 1)
            camControl.IsTouch = true;
            
    }

    public void OnClickUp(BaseEventData _eventData)
    {
        PointerEventData eventdata = (PointerEventData)_eventData;
        startPos = Vector3.zero;
        dir = Vector3.zero;
        touchMode = 0;
        GameManager.Instance.camDir = dir;
        camControl.IsTouch = false;
    }

    public void OnDrag(BaseEventData _eventData)
    {
        PointerEventData eventdata = (PointerEventData)_eventData;
        if (touchMode == 1)
        {
            dir = eventdata.position - (Vector2)startPos;
            dir.y = -(dir.x + dir.y);
            GameManager.Instance.camDir = dir;
        }
    }
    
}
