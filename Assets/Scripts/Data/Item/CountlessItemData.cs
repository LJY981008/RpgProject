using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CountlessItemData : ItemData
{
    public float MaxDurability => _maxDurability;
    [Header("최대 내구도")]
    [SerializeField] private float _maxDurability = 100;
}
