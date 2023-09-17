using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 전체 아이템 공통 데이터 
/// </summary>
public abstract class ItemData : ScriptableObject
{
    [Header("아이템 정보")]
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
    /// 아이템 생성
    /// </summary>
    public abstract Item CreateItem();
}
