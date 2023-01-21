using Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : IFactoryWeapon
{
    private IFactoryWeapon m_weapon;
    public IFactoryWeapon WeaponFactory => m_weapon;

    protected string m_weaponName;
    public string WeaponName => m_weaponName;

    protected int m_damage;
    public int Damage => m_damage;

    protected MeshRenderer m_meshRenderer;
    public MeshRenderer MeshRenderer => m_meshRenderer;

    protected Animator m_animator;
    protected string m_triggerAnimatorName;
    public void CreateWeapon(IFactoryWeapon weapon, string weaponName, Animator animator, int damage, MeshRenderer meshRenderer)
    {
        m_weapon = weapon;
        m_weaponName = weaponName;
        m_damage = damage;
    }

    public void ChangeWeapon(IFactoryWeapon factoryWeapon)
    {
        throw new System.NotImplementedException();
    }

    public abstract void Attack(AbstractCombat abstractCombat);
}
