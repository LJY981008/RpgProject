using UnityEngine;

namespace Observer {
    public interface ICanvasSubject
    {
        void ResistObserver(ICanvasObserver _observer);
        void RemoveObserver(ICanvasObserver _observer);
        void NotifyObserver();
    }
    public interface ICanvasObserver
    {
        void UpdateData(Canvas canvas);
    }
}
