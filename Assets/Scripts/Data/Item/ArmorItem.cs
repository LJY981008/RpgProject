using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : CountlessItem
{
    public ArmorItem(ArmorItemData data, float durability = 100) : base(data, durability) { }
    public void Upgrage()
    {
        if (Data is ArmorItemData data)
        {
            data.step++;
        }
    }
}
