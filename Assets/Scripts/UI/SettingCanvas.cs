using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer;
public class SettingCanvas : MonoBehaviour, ICanvasSubject
{
    private List<ICanvasObserver> observers = new List<ICanvasObserver>();
    private Canvas canvas;
    public void ResistObserver(ICanvasObserver _observer)
    {
        observers.Add(_observer);
    }

    public void RemoveObserver(ICanvasObserver _observer)
    {
        observers.Remove(_observer);
    }

    public void NotifyObserver()
    {
        foreach (ICanvasObserver observer in observers)
        {
            observer.UpdateData(canvas);
        }
    }

}
