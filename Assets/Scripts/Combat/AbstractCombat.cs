using Interfaces;
using UnityEngine;

namespace Combat
{
    public abstract class AbstractCombat : MonoBehaviour
    {
        protected int m_currentHp;

        public virtual void Damage(int damage)
        {
            m_currentHp -= damage;
            //After enemy death object come back to pool
            Debug.Log(m_currentHp);
        }

        public abstract void Attack();

        public abstract void SetTarget(AbstractCombat abstractCombat);

        public abstract void ResetHp();
    }
}