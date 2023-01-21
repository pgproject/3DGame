using Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponColliderContact : MonoBehaviour, ISubject<AbstractCombat>
{
    private bool m_isContactWithenemy;
    private AbstractCombat m_abstractCombat;
    private List<IObservator<AbstractCombat>> m_iobservators = new List<IObservator<AbstractCombat>>();

    

    public void AddObserver(IObservator<AbstractCombat> observer)
    {
        m_iobservators.Add(observer);
    }

    public void Notify()
    {
        for (int i = 0; i < m_iobservators.Count; i++)
        {
            m_iobservators[i].UpdateState(m_abstractCombat);
        }
    }

    public void RemoveObserver(IObservator<AbstractCombat> observer)
    {
        m_iobservators.Add(observer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
            m_abstractCombat = collision.collider.GetComponent<AbstractCombat>();
    }
}
