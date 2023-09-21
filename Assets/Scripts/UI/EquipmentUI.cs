using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentUI : MonoBehaviour, IBtnEvent
{
    public List<RectCheck> weaponSlotList;
    public List<RectCheck> armorSlotList;
    public Transform weaponSlotApply;
    public Transform weaponSlotParent;
    public Transform armorSlotApply;
    public Transform armorSlotParent;
    private RectCheck selectedSlot;
    private void Awake()
    {
        selectedSlot = null;
        for(int i = 0; i < weaponSlotParent.childCount; i++)
        {
            weaponSlotList.Add(weaponSlotParent.GetChild(i).GetComponent<RectCheck>());
        }
        for(int i = 0; i < armorSlotParent.childCount; i++)
        {
            armorSlotList.Add(armorSlotParent.GetChild(i).GetComponent<RectCheck>());
        }
    }
    private void OnEnable()
    {
        UpdateSlot();
    }
    public void UpdateSlot()
    {
        Item[] weapons = ToolManager.Instance.weapons;
        Item[] armors = ToolManager.Instance.armors;
 
        Transform weaponIconApply = Utill.FindTransform(weaponSlotApply, "Icon");
        weaponIconApply.gameObject.SetActive(true);
        weaponIconApply.GetComponent<Image>().sprite = ToolManager.Instance.applyWeapon.Data.ItemIcon;
        
        Transform armorIconApply = Utill.FindTransform(armorSlotApply, "Icon");
        armorIconApply.gameObject.SetActive(true);
        armorIconApply.GetComponent<Image>().sprite = ToolManager.Instance.applyArmor.Data.ItemIcon;

        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] != null)
            {
                if (weapons[i] is CountlessItem ci)
                {
                    Transform icon = Utill.FindTransform(weaponSlotList[i].transform, "Icon");
                    weaponSlotList[i].gameObject.SetActive(true);
                    icon.gameObject.SetActive(true);
                    icon.GetComponent<Image>().sprite = ci.Data.ItemIcon;
                }
            }
        }
        for(int i = 0; i < armors.Length; i++)
        {
            if(armors[i] != null)
            {
                if(armors[i] is CountlessItem ci)
                {
                    Transform icon = Utill.FindTransform(armorSlotList[i].transform, "Icon");
                    armorSlotList[i].gameObject.SetActive(true);
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
        bool isWeapon = false;
        int index = -1;

        foreach(RectCheck slot in weaponSlotList)
        {
            index++;
            if (slot.IsInRect(eventData.position))
            {
                selectedSlot = slot;
                isWeapon = true;
                break;
            }
        }
        if (!isWeapon)
        {
            index = -1;
            foreach(RectCheck slot in armorSlotList)
            {
                index++;
                if (slot.IsInRect(eventData.position))
                {
                    selectedSlot = slot;
                    break;
                }
            }
        }
        if(selectedSlot != null)
        {
            selectedIcon = Utill.FindTransform(selectedSlot.transform, "Icon").gameObject;
            if (selectedIcon.activeSelf)
            {
                if (isWeapon) ToolManager.Instance.EquipWeapon(index);
                else ToolManager.Instance.EquipArmor(index);
                UpdateSlot();
            }
            isWeapon = false;
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
