using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private PlayerCombat m_playerCombat;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Enemy>() != null)
            m_playerCombat.SetTarget(other.GetComponent<Enemy>());
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Enemy>() != null)
            m_playerCombat.SetTarget(null);
    }
}
