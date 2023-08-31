using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer;
public class HPSubject : MonoBehaviour, IHpSubject
{
    private List<IHpObserver> observers = new List<IHpObserver>();

    private float playerHp = 1;
    public float PlayerHp { get { return playerHp; } }
    private float monsterHp = 1;
    public float MonsterHp { get { return monsterHp; } }
    private int monsterID = 0;
    public int MonsterID { get { return monsterID; } }

    public void RegisterObserver(IHpObserver _observer)
    {
        observers.Add(_observer);
    }
    public void RemoveObserver(IHpObserver _observer)
    {
        observers.Remove(_observer);
    }

    public void NotifyObservers()
    {
        for (int i = 0; i < this.observers.Count; i++)
        {
            observers[i].UpdateData(playerHp, monsterHp, monsterID);
        }
    }

    public void Changed(float _playerHp, float _monsterHp, int _monsterID)
    {
        playerHp = _playerHp;
        monsterHp = _monsterHp;
        monsterID = _monsterID;
        NotifyObservers();
    }
}
