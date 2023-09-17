using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour,IBtnEvent
{
    public List<RectCheck> slotList;
    private RectCheck selectedSlot = null;

    private void Awake()
    {
        slotList = new List<RectCheck>();
        CheckedSlot();
    }



    public void CheckedSlot()
    {
        Transform listObj = transform.GetChild(0);
        for(int i = 0; i < listObj.childCount; i++)
        {
            slotList.Add(listObj.GetChild(i).GetComponent<RectCheck>());
        }
    }

    public void OnClickDown(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnClickUp(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        GameObject selectedIcon = null;
        foreach(RectCheck slot in slotList)
        {
            if (slot.IsInRect(eventData.position))
            {
                selectedSlot = slot;
                selectedIcon = Utill.FindTransform(selectedSlot.transform, "Icon").gameObject;
                break;
            }
        }
        if(selectedIcon != null && selectedIcon.activeSelf)
        {
            ToolManager.Instance.isSelected = true;
            ToolManager.Instance.selectedSlotToIcon = selectedIcon;
            selectedSlot = null;
        }

    }

    public void OnDrag(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }
}
