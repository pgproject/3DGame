using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class WeaponStats 
{
    [SerializeField] private string m_name;
    public string Name => m_name;

    [SerializeField] private MeshRenderer m_meshRenderer;
    public MeshRenderer MeshRenderer => m_meshRenderer;

    [SerializeField] private int m_damage;
    public int Damage => m_damage;

    [SerializeField] private Animator m_animator;
    public Animator Animator => m_animator;

}
