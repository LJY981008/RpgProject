using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item_Equipment_Armor", menuName = "Inventory System/Item Data/Equipment/Armor", order = 3)]
public class ArmorItemData : CountlessItemData
{
    /// <summary>
    /// 방어력
    /// </summary>
    public float Defence => _defence;
    [Header("방어력")]
    [SerializeField] private float _defence;

    public double AdditionalDefence => step * 2;
    [HideInInspector] public int step = 0;
    public override Item CreateItem()
    {
        return new ArmorItem(this);
    }
}
