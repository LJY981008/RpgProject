using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentUI : MonoBehaviour, IBtnEvent
{
    public List<RectCheck> slotList;
    public Transform applyWeapon;
    public Transform slotParent;
    private RectCheck selectedSlot;
    private void Awake()
    {
        applyWeapon = transform.GetChild(0);
        slotParent = transform.GetChild(1);
        selectedSlot = null;
        for(int i = 0; i < slotParent.childCount; i++)
        {
            slotList.Add(slotParent.GetChild(i).GetComponent<RectCheck>());
        }
    }
    private void OnEnable()
    {
        UpdateSlot(ToolManager.Instance.weapons);
    }
    public void UpdateSlot(Item[] items)
    {
        Transform applyIcon = Utill.FindTransform(applyWeapon, "Icon");
        applyIcon.gameObject.SetActive(true);
        applyIcon.GetComponent<Image>().sprite = ToolManager.Instance.applyWeapon.Data.ItemIcon;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                if (items[i] is CountlessItem ci)
                {
                    Transform icon = Utill.FindTransform(slotList[i].transform, "Icon");
                    slotList[i].gameObject.SetActive(true);
                    icon.gameObject.SetActive(true);
                    icon.GetComponent<Image>().sprite = ci.Data.ItemIcon;
                }
            }
        }
    }
    public void OnClickUp(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        GameObject selectedIcon = null;
        int index = -1;
        foreach(RectCheck slot in slotList)
        {
            index++;
            if (slot.IsInRect(eventData.position))
            {
                selectedSlot = slot;
                break;
            }
        }
        if(selectedSlot != null)
        {
            selectedIcon = Utill.FindTransform(selectedSlot.transform, "Icon").gameObject;
            if (selectedIcon.activeSelf)
            {
                ToolManager.Instance.EquipWeapon(index);
                UpdateSlot(ToolManager.Instance.weapons);
            }
            selectedSlot = null;
        }
    }
    public void OnClickDown(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }
    public void OnDrag(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }
}
