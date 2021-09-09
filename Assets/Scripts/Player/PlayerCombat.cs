using System;
using Combat;
using UnityEngine;

[Serializable]
public class PlayerCombat : AbstractCombat
{
    [SerializeField] private Animator m_animmator;
    [SerializeField] private Transform m_ragnedWeaponBarrelTransformm;
    
    private Enemy m_enemy;
    private PlayerStats m_playerStats;
    private RaycastHit m_raycastHit;

    private readonly int RANGED_ATTACK = Animator.StringToHash("RangedAttack");
    private readonly int MELEE_ATTACK = Animator.StringToHash("MeleeAttack");
    
    private void Awake()
    {
        m_playerStats = GeneralScriptableObject.Instance.PlayerStats;
        m_currentHp = m_playerStats.StartHp;
    }

    public override void MeleeAttack()
    {
        m_animmator.SetTrigger(MELEE_ATTACK);
    }

    public override void RangedAttack()
    {
        m_animmator.SetTrigger(RANGED_ATTACK);

        if (Physics.Raycast(m_ragnedWeaponBarrelTransformm.position, m_ragnedWeaponBarrelTransformm.forward,
            out m_raycastHit, m_playerStats.RangedAttackDistance))
        {
            if (m_raycastHit.rigidbody.GetComponent<Enemy>() != null)
                m_enemy = m_raycastHit.rigidbody.GetComponent<Enemy>();
        }
        else
        {
            m_enemy = null;
        }
        
        if (m_enemy != null)
        {
            m_enemy.Damage(m_playerStats.RangedAttackDamage);
        }
    }

    public override void SetTarget(AbstractCombat abstractCombat)
    {
        if (abstractCombat != null)
        {
            m_enemy = abstractCombat.GetComponent<Enemy>();
            m_enemy?.Damage(m_playerStats.MeleeAttackDamage);
        }
        else
        {
            m_enemy = null;
        }
    }

}
