using UnityEngine;

namespace Observer {
    public interface IHpSubject
    {
        void RegisterObserver(IHpObserver _observer);
        void RemoveObserver(IHpObserver _observer);
        void NotifyObservers();
    }
    public interface IHpObserver
    {
        void UpdateData(float playerHp, float monsterHp, int monsterID);
    }
}
