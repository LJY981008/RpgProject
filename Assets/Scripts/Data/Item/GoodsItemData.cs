using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��� ������ ������
/// </summary>
[CreateAssetMenu(fileName = "Item_Goods_", menuName = "Inventory System/Item Data/Goods", order = 3)]
public class GoodsItemData : CountableItemData
{
    
    public override Item CreateItem()
    {
        return new GoodsItem(this);
    }
}
