using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 소비 아이템 공통 데이터
/// </summary>
public abstract class CountableItemData : ItemData
{
    public int MaxAmount => _maxAmount;
    [Header("최대 보유량")]
    [SerializeField] private int _maxAmount = 99;
}
