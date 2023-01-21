using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", order = 1)]
public class WeaponScriptableObject : ScriptableObject
{

    [SerializeField] private string m_name;
    public string Name => m_name;

    [SerializeField] private int m_damage;
    public int Damage => m_damage;

    [SerializeField] private MeshRenderer m_meshRenderer;
    public MeshRenderer MeshRenderer => m_meshRenderer;

}
