using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class EnemyStats
{
    [SerializeField] private int m_startHp;
    public int StartHp => m_startHp;

    [SerializeField] private int m_damage;
    public int Damage => m_damage;

    [SerializeField] private float m_rangedattackDistance;
    public float RangedAttackDistance => m_rangedattackDistance;

    [SerializeField] private float m_speedMoving;
    public float SpeedMoving => m_speedMoving;

    [SerializeField] private float m_meleeAttackDistance;
    public float MeleeAttackDistance => m_meleeAttackDistance;
}
