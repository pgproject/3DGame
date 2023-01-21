using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCreator : MonoBehaviour
{
    [SerializeField] private Animator m_animator;


    private AbstractWeaponFactory  m_abstractWeaponFactory;
    private List<Weapon> m_weapons => Weapons.Instanse.WeaponsList;
    private MeshRenderer MeshRenderer;
    void Start()
    {
        m_abstractWeaponFactory = new WeaponFactory();
        Weapons.Instanse.CreateWeapon(m_abstractWeaponFactory, typeof(Sword));

        for (int i = 0; i < m_weapons.Count; i++)
        {
            m_weapons[i].CreateWeapon((IFactoryWeapon)typeof(Sword), typeof(Sword).ToString(), m_animator, 5, MeshRenderer); // do I need animaotor as parameter in this function?
        }
    }

}
