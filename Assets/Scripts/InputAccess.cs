using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class InputAccess
{

    [SerializeField] private InputActionProperty m_mouseDelta;
    public InputActionProperty MouseDelta => m_mouseDelta;

    [SerializeField] private InputActionProperty m_move;
    public InputActionProperty Move => m_move;
    
    [SerializeField] private InputActionProperty m_meleeAttack;
    public InputActionProperty MeleeAttack => m_meleeAttack;
    
    [SerializeField] private InputActionProperty m_rangedAttack;
    public InputActionProperty RangedAttack => m_rangedAttack;
    
}
