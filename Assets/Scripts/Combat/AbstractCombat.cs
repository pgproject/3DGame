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
        }
      
    }
}