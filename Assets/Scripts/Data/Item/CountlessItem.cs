using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� �� ���� ������ �̺�Ʈ
/// </summary>
public abstract class CountlessItem : Item
{
    public CountlessItemData CountlessData { get; private set; }
    /// <summary>
    /// ���系����
    /// </summary>
    public float Durability { get; protected set; }
    /// <summary>
    /// �ִ볻����
    /// </summary>
    public float MaxDurability => CountlessData.MaxDurability;
    /// <summary>
    /// ����ı�����
    /// </summary>
    public bool IsBroken => Durability <= 0;

    public CountlessItem(CountlessItemData data, float durability = 100) : base(data)
    {
        CountlessData = data;
        SetDurability(durability);
    }
    /// <summary>
    /// ������ ���� ����
    /// </summary>
    public void SetDurability(float durability)
    {
        Durability = Mathf.Clamp(durability, 0, MaxDurability);
    }
    /// <summary>
    /// ������ ������ �Ҹ�
    /// </summary>
    public void ConsumDurabilty(float amount)
    {
        float consum = Durability - amount;
        SetDurability(consum);
    }
    /// <summary>
    /// ������ ������ ����
    /// </summary>
    public void RepairDurability()
    {
        SetDurability(CountlessData.MaxDurability);
    }
}