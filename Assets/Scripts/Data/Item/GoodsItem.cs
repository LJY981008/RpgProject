using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsItem : CountableItem, IUseItem
{
    public GoodsItem(GoodsItemData data, int amount = 1) : base(data, amount) { }

    public bool Use(int num)
    {
        // 소모량 만큼 감소
        Amount -= num;
        return true;
    }
    protected override CountableItem Clone(int amount)
    {
        return new GoodsItem(CountableData as GoodsItemData, amount);
    }
}
