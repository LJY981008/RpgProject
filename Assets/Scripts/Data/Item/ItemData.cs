using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ��ü ������ ���� ������ 
/// </summary>
public abstract class ItemData : ScriptableObject
{
    [Header("������ ����")]
    [SerializeField]
    private ItemType type;
    public ItemType Type { get { return type; } }
    [SerializeField]
    private int itemID;
    public int ItemID { get { return itemID; } }
    [SerializeField]
    private Sprite itemIcon;
    public Sprite ItemIcon { get { return itemIcon; } }

    /// <summary>
    /// ������ ����
    /// </summary>
    public abstract Item CreateItem();
}
