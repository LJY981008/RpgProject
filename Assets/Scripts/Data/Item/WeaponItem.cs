using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : CountlessItem
{
    public WeaponItem(WeaponItemData data, float durability = 100) : base(data, durability) { }
    public void Upgrage()
    {
        if(Data is WeaponItemData wd)
        {
            wd.step++;
        }
    }
}
