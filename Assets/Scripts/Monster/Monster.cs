
using UnityEngine;

public enum MonsterType
{
    Goblin,
    Orc
}
public abstract class Monster : MonoBehaviour
{
    protected MonsterType type;
    protected Transform tr;
    protected int hp;
    protected float damage;
    public abstract void Attack();
}
