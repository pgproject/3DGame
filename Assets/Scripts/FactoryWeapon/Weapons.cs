using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Weapons
{
    private List<Weapon> m_weapons = new List<Weapon>();
    public List<Weapon> WeaponsList => m_weapons;

    private Type m_type;
    private static Weapons m_instance = null;

    public static Weapons Instanse
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new Weapons();
            }

            return m_instance;
        }
    }
    
    private Weapons () { }

    public void CreateWeapon(AbstractWeaponFactory weaponFactory, Type type)
    {
        m_type = type;
        m_weapons.Add(weaponFactory.Weapon(type));
    }
    
}
