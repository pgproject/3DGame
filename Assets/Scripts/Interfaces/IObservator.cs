using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservator<T>
{
    void UpdateState(T parametr);
}
