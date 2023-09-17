using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryUI : MonoBehaviour,IBtnEvent
{
    public List<RectCheck> slotList;
    private RectCheck selectedSlot = null;

    private void Awake()
    {
        slotList = new List<RectCheck>();
        CheckedSlot();
        ToolManager.Instance.inventoryUI = this;
    }
    private void OnEnable()
    {
        ToolManager.Instance.inventoryUI = this;
        UpdateSlot(ToolManager.Instance.items);
    }
    public void CheckedSlot()
    {
        Transform listObj = transform.GetChild(0);
        for(int i = 0; i < listObj.childCount; i++)
        {
            slotList.Add(listObj.GetChild(i).GetComponent<RectCheck>());
        }
    }
    /// <summary>
    /// UI °»½Å
    /// </summary>
    /// <param name="index"></param>
    public void UpdateSlot(Item[] items)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] != null)
            {
                if(items[i] is CountableItem ci)
                {
                    Transform icon = Utill.FindTransform(slotList[i].transform, "Icon");
                    TextMeshProUGUI textAmount = icon.GetChild(0).GetComponent<TextMeshProUGUI>();
                    slotList[i].gameObject.SetActive(true);
                    icon.gameObject.SetActive(true);
                    icon.GetComponent<Image>().sprite = ci.Data.ItemIcon;
                    textAmount.text = ci.Amount.ToString();
                }
            }
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
