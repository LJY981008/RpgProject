using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIScrollEvent : MonoBehaviour, IBtnEvent
{
    public RectTransform scrollVIew;
    public float openSpeed = 1000f;
    private bool isOpen = false;
    private bool isFlag = false;

    int itemCount = 0;
    float itemSize = 0;
    float destSize = 0;
    Vector2 size;
    private void Awake()
    {
        size = Vector2.zero;
    }

    private void Start()
    {
        itemCount = Utill.FindTransform(scrollVIew.transform, "Content").childCount;
        if(itemCount > 0)
        {
            itemSize = Utill.FindTransform(scrollVIew.transform, "Content")
                .GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        }
        destSize = itemCount * (itemSize + 10);
    }


    public void OnClickUp(BaseEventData _eventData)
    {
        if (!isFlag)
        {
            size = scrollVIew.sizeDelta;
            isFlag = true;
        }
    }

    private void Update()
    {
        if (isFlag) 
        {
            if (isOpen)
            {
                if (size.x <= 0)
                {
                    isFlag = false;
                    isOpen = false;
                    size.x = 0;
                    scrollVIew.sizeDelta = size;
                }
                else
                {
                    size.x -= Time.deltaTime * openSpeed;
                    scrollVIew.sizeDelta = size;
                }
            }
            else
            {
                if (size.x >= destSize)
                {
                    isFlag = false;
                    isOpen = true;
                    size.x = destSize;
                    scrollVIew.sizeDelta = size;
                }
                else
                {
                    size.x += Time.deltaTime * openSpeed;
                    scrollVIew.sizeDelta = size;
                }
            }
        }
    }










    public void OnClickDown(BaseEventData _eventData)
    { 
    }
    public void OnDrag(BaseEventData _eventData)
    {
    }
}
