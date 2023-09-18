using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CountlessItemData : ItemData
{
    public float MaxDurability => _maxDurability;
    [Header("�ִ� ������")]
    [SerializeField] private float _maxDurability = 100;
}
