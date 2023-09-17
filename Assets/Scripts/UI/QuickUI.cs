using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuickUI : MonoBehaviour, IBtnEvent
{
    public List<RectCheck> slotList;
    private RectCheck selectedSlot = null;
    
    private void Awake()
    {
        CheckedSlot();
        ToolManager.Instance.quickUI = this;
    }
    public void CheckedSlot()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            slotList.Add(transform.GetChild(i).GetComponent<RectCheck>());
        }
    }

    public void OnClickDown(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnClickUp(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        Image icon = null;
        GameObject thisIcon = null;
        int index = -1;
        foreach (RectCheck slot in slotList)
        {
            index++;
            if (slot.IsInRect(eventData.position))
            {
                selectedSlot = slot;
                thisIcon = Utill.FindTransform(selectedSlot.transform, "Icon").gameObject;
                icon = ToolManager.Instance.selectedSlotToIcon.GetComponent<Image>();
                break;
            }
        }
        if (selectedSlot != null)
        {
            if (ToolManager.Instance.isSelected)
            {
                thisIcon.SetActive(true);
                thisIcon.GetComponent<Image>().sprite = icon.sprite;
                ToolManager.Instance.AddQuickItem(index);
                ToolManager.Instance.isSelected = false;
            }
        }
        index = -1;
        selectedSlot = null;
    }

    public void OnDrag(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }
}
