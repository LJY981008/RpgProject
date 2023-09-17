using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    NONE = 100000,
    Portion,
    EquipMent,
    Goods
}
public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;

    public DungeonQuickUI dungeonQuickUI;
    public InventoryUI inventoryUI;
    public QuickUI quickUI;

    public GameObject selectedSlotToIcon = null;
    public int selectedSlotIndex = -1;
    public bool isSelected = false;

    private int maxSizeItems = 25;
    private int maxSizeQuicks = 3;
    public Item[] items;
    public Item[] quicks;
    public ItemData portionData;
    public ItemData goodsData;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        items = new Item[maxSizeItems];
        quicks = new Item[maxSizeQuicks];
        AddItem(portionData, 12);
    }
    /// <summary>
    /// 동일 아이템 찾기
    /// </summary>
    public int FindItem(CountableItemData data)
    {
        int result = -1;
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                if (items[i].Data.ItemID == data.ItemID)
                {
                    result = i;
                }
            }
            
        }
        return result;

    }
    public int FindEmpty()
    {
        int index = -1;
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] == null)
            {
                index = i;
                break;
            }
        }
        return index;
    }
    /// <summary>
    /// 아이템 습득
    /// </summary>
    public void AddItem(ItemData item, int num)
    {
        int emptyIndex = -1;    // 빈공간
        int clashIndex = -1;    // 겹침
        if (item is CountableItemData data)
        {
            clashIndex = FindItem(data);
            // 겹치는 데이터가 있을 때
            if (clashIndex > -1)
            {
                CountableItem ci = items[clashIndex] as CountableItem;
                ci.AddAmountAndGetExcess(num);
            }
            // 겹치는 데이터가 없을 때
            else
            {
                emptyIndex = FindEmpty();
                CountableItem ci = data.CreateItem() as CountableItem;
                ci.SetAmount(num);
                items[emptyIndex] = ci;
            }
        }
        if (inventoryUI != null)
            inventoryUI.UpdateSlot(items);
    }
    public void AddQuickItem(int index)
    {
        quicks[index] = items[selectedSlotIndex];
    }
    public void UseItem(int index, int num)
    {
        if (quicks[index] == null) return;
        if (quicks[index] is IUseItem uItem)
        {
            if (uItem.Use(num))
            {
                Player.Instance.Heal(uItem.GetValue());
                if (dungeonQuickUI != null)
                    dungeonQuickUI.UpdateSlot(quicks);
            }
        }
    }
}
