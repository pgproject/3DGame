using Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactoryWeapon
{
    void Attack(AbstractCombat abstractCombat);
    void CreateWeapon(IFactoryWeapon factoryWeapon, string weaponName, Animator animator, int damage, MeshRenderer meshRenderer);
    void ChangeWeapon(IFactoryWeapon factoryWeapon);
}
