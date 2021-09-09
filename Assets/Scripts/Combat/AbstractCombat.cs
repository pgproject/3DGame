using Interfaces;
using UnityEngine;

namespace Combat
{
    public abstract class AbstractCombat : MonoBehaviour
    {
        protected int m_currentHp;

        public void Damage(int damage)
        {
            m_currentHp -= damage;
            Debug.Log(m_currentHp);
        }

        public abstract void MeleeAttack();

        public abstract void RangedAttack();

        public abstract void SetTarget(AbstractCombat abstractCombat);
    }
}