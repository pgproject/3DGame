using System;
using System.Net.Sockets;
using Combat;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : AbstractCombat
{
    [SerializeField] private Transform m_rangedWeaponTransform;
    [SerializeField] private Transform m_playerTransform;
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private Pool m_enemiesPool;
    
    private EnemyStats m_enemyStats;
    private RaycastHit m_raycastHit;
    private void Awake()
    {
        m_enemyStats = GeneralScriptableObject.Instance.EnemyStats;
        m_currentHp = m_enemyStats.StartHp;
    }

    private PlayerCombat m_playerCombat;
    private enum AttackEnemyType
    {
        Ranged,
        Melee
    }

    private AttackEnemyType m_attackEnemyType;

    public void ChasePlayer()
    {
        if (m_attackEnemyType == AttackEnemyType.Ranged)
        {
            if (Physics.Raycast(m_rangedWeaponTransform.position,
                m_rangedWeaponTransform.forward, out m_raycastHit, m_enemyStats.RangedAttackDistance))
            {
                if (m_raycastHit.rigidbody.GetComponent<PlayerCombat>() != null)
                {
                    m_playerCombat = m_raycastHit.rigidbody.GetComponent<PlayerCombat>();
                    //RangedAttack();
                }
                else
                {
                    m_playerCombat = null;
                }
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, m_playerTransform.transform.position) > m_enemyStats.MeleeAttackDistance)
                m_rigidbody.MovePosition(m_playerTransform.position);
            else if(m_playerCombat != null)
            {
                //MeleeAttack();
            }
        }
    }
    
    

    public override void SetTarget(AbstractCombat abstractCombat)
    {
        if (abstractCombat != null)
            m_playerCombat = abstractCombat.GetComponent<PlayerCombat>();
        else
        {
            m_playerCombat = null;
        }
    }

    public override void ResetHp()
    {
        m_currentHp = m_enemyStats.StartHp;
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        if (m_currentHp <= 0)
            m_enemiesPool.PutObjectToPool(this.gameObject);
    }

    private void OnValidate()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }
}
