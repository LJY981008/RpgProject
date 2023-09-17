using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionItem : CountableItem, IUseItem
{
    public PortionItem(PortionItemData data, int amount = 1) : base(data, amount) { }
    public bool Use(int num)
    {
        // ���� �ϳ� ����
        Amount -= num;

        return true;
    }
    public float GetValue()
    {
        float value = 0;
        if(Data is PortionItemData pi)
        {
            value = pi.Value;
        }
        return value;
    }

    protected override CountableItem Clone(int amount)
    {
        return new PortionItem(CountableData as PortionItemData, amount);
    }
}
