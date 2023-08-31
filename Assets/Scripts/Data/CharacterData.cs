using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chracter Data", menuName = "Scriptable Object/Chracter Data", order = int.MaxValue)]
public class CharacterData : ScriptableObject
{
    [SerializeField]
    private float maxHp;
    public float MaxHp { get { return maxHp; } }
    [SerializeField]
    private float power;
    public float Power { get { return power; } }
}
