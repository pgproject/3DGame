using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStats
{
    [SerializeField] private int m_maxHp;
    public int MaxHp => m_maxHp;

    [SerializeField] private int m_startHp;
    public int StartHp => m_startHp;

    [SerializeField] private int m_meleeAttackDamage;
    public int MeleeAttackDamage => m_meleeAttackDamage;


    [SerializeField] private int m_rangedAttackDamage;
    public int RangedAttackDamage => m_rangedAttackDamage;

    [SerializeField] private float m_rangedAttackDistance;
    public float RangedAttackDistance => m_rangedAttackDistance;
    
    [SerializeField] private float m_speedMoving;
    public float SpeedMoving => m_speedMoving;
    
    [SerializeField] private float m_cameraYRotationMin, m_cameraYRotationMax;
    public float CameraYRotationMin => m_cameraYRotationMin;
    public float CameraYRotationMax => m_cameraYRotationMax;
    [SerializeField] private float m_mouseSensitivity;
    public float MouseSensitivity => m_mouseSensitivity;
    [SerializeField] private float m_cameraSmoothing;
    public float CameraSmoothing => m_cameraSmoothing;
}
