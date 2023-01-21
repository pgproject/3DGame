using Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public override void Attack(AbstractCombat abstractCombat)
    {
        m_animator.SetTrigger(m_triggerAnimatorName);

        //if (Physics.Raycast)
    }
}
