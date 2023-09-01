using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Observer;
using TMPro;
public class MonsterHp : MonoBehaviour, IHpObserver
{
    public bool isChanged = false;
    public float currentHp = 1.1f;
    public TextMeshProUGUI monsterName;
    private float speed = 3f;
    private Image hpBar;
    private HPSubject subject;
    private int monsterID = 0;
    private void Awake()
    {
        hpBar = GetComponent<Image>();
        GameManager.Instance.monsterObserver = this;
        subject = GameManager.Instance.HpSubject;
        gameObject.SetActive(false);
        monsterName.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        subject.RegisterObserver(this);
    }
    private void OnDisable()
    {
        subject.RemoveObserver(this);
    }
    private void Update()
    {
        if (isChanged)
        {
            hpBar.fillAmount = currentHp;
            isChanged = false;
        }
        if(hpBar.fillAmount > currentHp)
        {
            hpBar.fillAmount -= (Time.deltaTime * speed);
        }
    }

    public void UpdateData(float playerHp, float monsterHp, int _monsterID, string _monsterName)
    {
        currentHp = monsterHp;
        monsterName.text = _monsterName;
        if(monsterID != _monsterID)
        {
            isChanged = true;
            monsterID = _monsterID;
        }
            
    }
}