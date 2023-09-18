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
    public bool isOpenInventory = false;

    /// <summary>
    /// �κ��丮 ������
    /// </summary>
    private int maxSizeItems = 25;
    private int maxSizeQuicks = 3;
    public Item[] inventoryItems;
    public Item[] quicks;
    public ItemData portionData;
    public ItemData goodsData;

    /// <summary>
    /// ��� ������
    /// </summary>
    private int maxSizeWeapons = 4;
    private int maxSizeDefence = 4;
    public Item[] weapons;
    public Item[] defences;
    public Item applyWeapon;
    public Item applyDefence;
    public ItemData[] weaponsData;
    public ItemData[] defencesData;
    

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        inventoryItems = new Item[maxSizeItems];
        quicks = new Item[maxSizeQuicks];
        weapons = new Item[maxSizeWeapons];
        defences = new Item[maxSizeDefence];
        AddItem(portionData, 12);
        AddWeapon(weaponsData[0]);
        AddWeapon(weaponsData[1]);
        EquipWeapon(0);
    }
    /// <summary>
    /// ���� ������ ã��
    /// </summary>
    public int FindItem(CountableItemData data)
    {
        int result = -1;
        for(int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] != null)
            {
                if (inventoryItems[i].Data.ItemID == data.ItemID)
                {
                    result = i;
                }
            }
            
        }
        return result;

    }
    public int FindEmpty(Item[] items)
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
                CountableItem ci = inventoryItems[clashIndex] as CountableItem;
                ci.AddAmountAndGetExcess(num);
            }
            // ��ġ�� �����Ͱ� ���� ��
            else
            {
                emptyIndex = FindEmpty(inventoryItems);
                CountableItem ci = data.CreateItem() as CountableItem;
                ci.SetAmount(num);
                inventoryItems[emptyIndex] = ci;
            }
        }
        if (inventoryUI != null)
            inventoryUI.UpdateSlot(inventoryItems);
    }
    public void AddQuickItem(int index)
    {
        quicks[index] = inventoryItems[selectedSlotIndex];
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
    public void EquipWeapon(int index)
    {
        applyWeapon = weapons[index];
    }
    public void AddWeapon(ItemData weapon)
    {
        int emptyIndex = -1;
        if (weapon is CountlessItemData data)
        {
            CountlessItem ci = data.CreateItem() as CountlessItem;
            ci.SetDurability(data.MaxDurability);
            emptyIndex = FindEmpty(weapons);
            weapons[emptyIndex] = ci;
        }
    }
}
