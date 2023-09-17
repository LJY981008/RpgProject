using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 포션 아이템 데이터
/// </summary>
[CreateAssetMenu(fileName = "Item_Portion_", menuName = "Inventory System/Item Data/Portion", order = 3)]
public class PortionItemData : CountableItemData
{
    /// <summary> 효과량(회복량 등) </summary>
    public float Value => _value;
    [Header("회복량")]
    [SerializeField] private float _value;

    public override Item CreateItem()
    {
        return new PortionItem(this);
    }
}
