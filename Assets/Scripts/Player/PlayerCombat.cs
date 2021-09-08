using System;
using Combat;
using UnityEngine;

[Serializable]
public class PlayerCombat : AbstractCombat
{
    [SerializeField] private Animator m_animmator;
    [SerializeField] private Transform m_ragnedWeaponBarrelTransformm;
    
    private AbstractCombat m_enemy;
    private PlayerStats m_playerStats;
    private RaycastHit m_raycastHit;

    private readonly int RANGED_ATTACK = Animator.StringToHash("RangedAttack");
    private readonly int MELEE_ATTACK = Animator.StringToHash("MeleeAttack");
    
    private void Awake()
    {
        m_playerStats = GeneralScriptableObject.Instance.PlayerStats;
        m_currentHp = m_playerStats.StartHp;
    }

    public void MeleeAttack()
    {
        m_animmator.SetTrigger(MELEE_ATTACK);
        m_enemy?.Damage(m_playerStats.MeleeAttackDamage);
    }

    public void RangedAttack()
    {
        m_animmator.SetTrigger(RANGED_ATTACK);

        if (Physics.Raycast(m_ragnedWeaponBarrelTransformm.position, m_ragnedWeaponBarrelTransformm.forward,
            out m_raycastHit, m_playerStats.RangedAttackDistance))
            if (m_raycastHit.rigidbody.GetComponent<AbstractCombat>() != null)
                m_enemy = m_raycastHit.rigidbody.GetComponent<AbstractCombat>();
    
        if (m_enemy != null)
        {
            m_enemy.Damage(m_playerStats.RangedAttackDamage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AbstractCombat>() != null)
            m_enemy = other.GetComponent<AbstractCombat>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<AbstractCombat>() != null)
            m_enemy = null;
    }

}
