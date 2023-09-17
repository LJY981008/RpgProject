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
    /// ���� ������ ã��
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
    /// ������ ����
    /// </summary>
    public void AddItem(ItemData item, int num)
    {
        int emptyIndex = -1;    // �����
        int clashIndex = -1;    // ��ħ
        if (item is CountableItemData data)
        {
            clashIndex = FindItem(data);
            // ��ġ�� �����Ͱ� ���� ��
            if (clashIndex > -1)
            {
                CountableItem ci = items[clashIndex] as CountableItem;
                ci.AddAmountAndGetExcess(num);
            }
            // ��ġ�� �����Ͱ� ���� ��
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
