using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class InputAccess
{
    [SerializeField] private InputActionProperty m_mousePosition;
    public InputActionProperty MousePosition => m_mousePosition;

    [SerializeField] private InputActionProperty m_leftArrow;
    public InputActionProperty LeftArrow => m_leftArrow;

    [SerializeField] private InputActionProperty m_rightArrow;
    public InputActionProperty RightArrow => m_rightArrow;

    [SerializeField] private InputActionProperty m_downArrow;
    public InputActionProperty DownArrow => m_downArrow;

    [SerializeField] private InputActionProperty m_upArrow;
    public InputActionProperty UpArrow => m_upArrow;
    
    [SerializeField] private InputActionProperty m_meleeAttack;
    public InputActionProperty MeleeAttack => m_meleeAttack;
    
    [SerializeField] private InputActionProperty m_rangedAttack;
    public InputActionProperty RangedAttack => m_rangedAttack;
    
}
