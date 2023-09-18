using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 셀 수 없는 아이템 이벤트
/// </summary>
public abstract class CountlessItem : Item
{
    public CountlessItemData CountlessData { get; private set; }
    /// <summary>
    /// 현재내구도
    /// </summary>
    public float Durability { get; protected set; }
    /// <summary>
    /// 최대내구도
    /// </summary>
    public float MaxDurability => CountlessData.MaxDurability;
    /// <summary>
    /// 장비파괴여부
    /// </summary>
    public bool IsBroken => Durability <= 0;

    public CountlessItem(CountlessItemData data, float durability = 100) : base(data)
    {
        CountlessData = data;
        SetDurability(durability);
    }
    /// <summary>
    /// 내구도 범위 지정
    /// </summary>
    public void SetDurability(float durability)
    {
        Durability = Mathf.Clamp(durability, 0, MaxDurability);
    }
    /// <summary>
    /// 아이템 내구도 소모
    /// </summary>
    public void ConsumDurabilty(float amount)
    {
        float consum = Durability - amount;
        SetDurability(consum);
    }
    /// <summary>
    /// 아이템 내구도 수리
    /// </summary>
    public void RepairDurability()
    {
        SetDurability(CountlessData.MaxDurability);
    }
}