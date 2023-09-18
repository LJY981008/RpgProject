using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item_Equipment_", menuName = "Inventory System/Item Data/Equipment", order = 3)]
public class WeaponItemData : CountlessItemData
{
    /// <summary>
    /// ���ݷ�
    /// </summary>
    public float Power => _power;
    [Header("���ݷ�")]
    [SerializeField] private float _power;

    public double AdditionalPower => step * 5;
    [HideInInspector] public int step = 0;

    public override Item CreateItem()
    {
        return new WeaponItem(this);
    }
}
