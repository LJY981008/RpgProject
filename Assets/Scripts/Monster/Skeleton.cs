using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Skeleton : Monster
{
    [SerializeField]
    private CharacterData skeletonData;
    private HPSubject hpSubject = null;
    private MonsterHp observer = null;
    private float currentHp;
    private float changedHp;
    [SerializeField]
    private SkeletonPattern pattern;
    private bool isAttackFlag = false;
    
    private void Awake()
    {
        type = MonsterType.Skeleton;
        hp = skeletonData.MaxHp;
        power = skeletonData.Power;
        currentHp = hp;
        hpSubject = GameManager.Instance.HpSubject;
        observer = GameManager.Instance.monsterObserver;
    }
    private void Update()
    {
        if (currentHp <= 0f)
        {
            pattern.Die();
            observer.gameObject.SetActive(false);
            observer.monsterName.gameObject.SetActive(false);
        }
            
    }
    public override float Attack()
    {
        Debug.Log("공격");
        if (isAttackFlag)
        {
            Debug.Log("플래그");
            isAttackFlag = false;
            return power;
        }
        return 0;
    }
    public void UpdateAttack()
    {
        isAttackFlag = true;
    }
    public override void Hit(float damage)
    {
        if (Utill.RandomChance(10)) damage *= 2;
        currentHp -= damage;
        changedHp = currentHp / hp;
        observer.gameObject.SetActive(true);
        observer.monsterName.gameObject.SetActive(true);
        hpSubject.Changed(hpSubject.PlayerHp, changedHp, transform.GetInstanceID(), "Skeleton");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && Player.Instance.isAttackFlag)
        {
            Hit(Player.Instance.Power);
            Player.Instance.isAttackFlag = false;
        }
    }

    
}
