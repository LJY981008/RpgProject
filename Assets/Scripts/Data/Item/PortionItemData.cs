using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� ������ ������
/// </summary>
[CreateAssetMenu(fileName = "Item_Portion_", menuName = "Inventory System/Item Data/Portion", order = 3)]
public class PortionItemData : CountableItemData
{
    /// <summary> ȿ����(ȸ���� ��) </summary>
    public float Value => _value;
    [Header("ȸ����")]
    [SerializeField] private float _value;

    public override Item CreateItem()
    {
        return new PortionItem(this);
    }
}