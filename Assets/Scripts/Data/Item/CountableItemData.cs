using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Һ� ������ ���� ������
/// </summary>
public abstract class CountableItemData : ItemData
{
    public int MaxAmount => _maxAmount;
    [Header("�ִ� ������")]
    [SerializeField] private int _maxAmount = 99;
}
