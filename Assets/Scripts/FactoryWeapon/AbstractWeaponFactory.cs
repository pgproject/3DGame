using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : AbstractWeaponFactory
{
    public override Weapon Weapon(Type type)
    {
        if (type == typeof(Sword))
            return new Sword();
        else
            return new MeleeWeapon();
    }
}
