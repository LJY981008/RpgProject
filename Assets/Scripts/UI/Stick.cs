using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Stick : MonoBehaviour, IBtnEvent
{

    public Image inner;
    public RectTransform outter; // �ڱ��ڽ��� Rect
    public Vector3 Dir
    {
        get { return dir; }
    }
    private Vector3 startPos; // ���� ����
    private Vector3 dir; // ���� ����
    private float radius; // outter ������

    private void Start()
    {
        startPos = inner.transform.position;
        radius = outter.rect.width * 0.5f;
        dir = Vector3.zero;
    }
    public void OnClickDown(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        Debug.Log("aa");
        startPos = inner.transform.position;
        inner.transform.position = eventData.position;
    }

    public void OnClickUp(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        inner.transform.position = startPos;
        dir = Vector3.zero;
        GameManager.Instance.playerDir = dir;
    }
    public void OnDrag(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        dir = eventData.position - (Vector2)startPos;
        float distance = Vector3.Distance(startPos, eventData.position);
        if (distance > radius)
            inner.transform.position = startPos + dir.normalized * radius;
        else
            inner.transform.position = startPos + dir.normalized * distance;
        GameManager.Instance.playerDir = dir;
    }

}
