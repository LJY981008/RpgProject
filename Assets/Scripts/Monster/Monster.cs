
using UnityEngine;

public enum MonsterType
{
    Skeleton,
    Orc
}
public abstract class Monster : MonoBehaviour
{
    protected MonsterType type;
    protected Transform tr;
    protected float hp;
    protected float power;
    public abstract float Attack();
    public abstract void Hit(float damage);
}
