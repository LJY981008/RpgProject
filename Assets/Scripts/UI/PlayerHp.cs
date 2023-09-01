using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Observer;
public class PlayerHp : MonoBehaviour, IHpObserver
{
    private float currentHp = 1;
    private float speed;
    private Image hpBar;
    private HPSubject subject;
    private void Awake()
    {
        speed = 3f;
        hpBar = GetComponent<Image>();
    }
    private void Start()
    {
        subject = GameManager.Instance.HpSubject;
        subject.RegisterObserver(this);
    }
    private void Update()
    {
        if (hpBar.fillAmount > currentHp)
        {
            hpBar.fillAmount -= (Time.deltaTime * speed);
        }
    }
    
    public void UpdateData(float playerHp, float monsterHp, int monsterID, string monsterName)
    {
        currentHp = playerHp;
    }
}
