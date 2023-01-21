using System;
using Combat;
using UnityEngine;

[Serializable]
public class PlayerCombat : AbstractCombat, IObservator<AbstractCombat>
{
    [SerializeField] private Animator m_animmator;
    [SerializeField] private Transform m_ragnedWeaponBarrelTransformm;
    
    private Enemy m_enemy;
    private PlayerStats m_playerStats;
    private RaycastHit m_raycastHit;

    private readonly int RANGED_ATTACK = Animator.StringToHash("RangedAttack");
    private readonly int MELEE_ATTACK = Animator.StringToHash("MeleeAttack");

    private Weapon m_actualWeapon;

    private void Awake()
    {
        m_playerStats = GeneralScriptableObject.Instance.PlayerStats;
        m_currentHp = m_playerStats.StartHp;
    }

    public override void Attack()
    {
        //m_animmator.SetTrigger(RANGED_ATTACK);

        /*  if (Physics.Raycast(m_ragnedWeaponBarrelTransformm.position, m_ragnedWeaponBarrelTransformm.forward,
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
          }*/

        m_actualWeapon.Attack(m_enemy.GetComponent<AbstractCombat>()); 
    }

    public override void SetTarget(AbstractCombat abstractCombat)
    {
        m_enemy = abstractCombat.GetComponent<Enemy>();
        m_enemy?.Damage(m_playerStats.MeleeAttackDamage);
    }

    public override void ResetHp()
    {
        m_currentHp = m_playerStats.StartHp;
    }

    public void UpdateState(AbstractCombat enemyAbstractCombat)
    {
        enemyAbstractCombat.Damage(m_actualWeapon.Damage);
    }
}
