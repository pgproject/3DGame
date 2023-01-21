using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject<T>
{
    void AddObserver(IObservator<T> observer);
    void RemoveObserver(IObservator<T> observer);
    void Notify();
}
