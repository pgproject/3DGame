using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private Transform m_cameraTransform;
    [SerializeField] private PlayerCombat m_playerCombat;

    
    private float m_yRotation;
    private float m_speedRotateHorizontal;

    private InputAccess m_inputAccess;
    private PlayerStats m_playerStats;
    private InputAction m_mousePositionX;
    private void Awake()
    {
        m_inputAccess = GeneralScriptableObject.Instance.InputAccess;
        m_playerStats = GeneralScriptableObject.Instance.PlayerStats;
        
        m_inputAccess.UpArrow.reference.action.canceled += StopMove;
        m_inputAccess.DownArrow.reference.action.canceled += StopMove;
        m_inputAccess.LeftArrow.reference.action.canceled += StopMove;
        m_inputAccess.RightArrow.reference.action.canceled += StopMove;
        
        m_speedRotateHorizontal = m_playerStats.SpeedHorizontalRotation;
        m_mousePositionX = m_inputAccess.MousePositionX.reference.action;
    }

    private Vector3 m_forwardDirection;
    private Vector3 m_rightDirection;
    void Update()
    { 
       
        m_yRotation = m_mousePositionX.ReadValue<float>() * Time.fixedDeltaTime * m_speedRotateHorizontal;

        transform.localRotation = Quaternion.Euler(0, m_yRotation, 0);
        
        m_forwardDirection = m_cameraTransform.forward;
        m_rightDirection = m_cameraTransform.right;
        
        
        if (m_inputAccess.UpArrow.reference.action.ReadValue<float>() > 0)
            Move(m_forwardDirection);
        
        if (m_inputAccess.DownArrow.reference.action.ReadValue<float>() > 0) 
            Move(-m_forwardDirection);
        
        if (m_inputAccess.LeftArrow.reference.action.ReadValue<float>() > 0) 
            Move(-m_rightDirection); 
        
        if (m_inputAccess.RightArrow.reference.action.ReadValue<float>() > 0) 
            Move(m_rightDirection);

        if (m_inputAccess.MeleeAttack.reference.action.triggered)
            m_playerCombat.MeleeAttack();
        
        if (m_inputAccess.RangedAttack.reference.action.triggered)
            m_playerCombat.RangedAttack();
        
    }

    private void OnValidate()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_playerCombat = GetComponent<PlayerCombat>();
    }

    private void Move(Vector3 direction)
    {
        m_rigidbody.velocity = direction * m_playerStats.SpeedMoving;
    }

    private void StopMove(InputAction.CallbackContext obj)
    {
        ResetAddRigidbody();
    }

    private void ResetAddRigidbody()
    {
        m_rigidbody.velocity = Vector3.zero;
        m_rigidbody.angularVelocity = Vector3.zero;
    }
}