using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeWeapon : MonoBehaviour
{
    [SerializeField] private Enemy m_enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerCombat>() != null)
            m_enemy.SetTarget(other.GetComponent<PlayerCombat>());
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<PlayerCombat>() != null)
            m_enemy.SetTarget(null);
    }

    private void OnValidate()
    {
        m_enemy = transform.root.GetComponent<Enemy>();
    }
}
