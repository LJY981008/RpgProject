using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 재료 아이템 데이터
/// </summary>
[CreateAssetMenu(fileName = "Item_Goods_", menuName = "Inventory System/Item Data/Goods", order = 3)]
public class GoodsItemData : CountableItemData
{
    
    public override Item CreateItem()
    {
        return new GoodsItem(this);
    }
}
