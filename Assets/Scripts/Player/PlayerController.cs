using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_speedRotateHorizontal = 10f;
    [SerializeField] private float m_speedMoving;
    [SerializeField] private Rigidbody m_rigidbody;

    private Camera m_camera;
    private Transform m_cameraTreabsform;
    private float m_yRotation;

    private InputAccess m_inputAccess;

    [SerializeField] private PlayerCombat m_playerCombat;
    private void Awake()
    {
        m_inputAccess = GeneralScriptableObject.Instance.InputAccess;
        m_camera = Camera.main;
        m_cameraTreabsform = m_camera.transform;

        m_inputAccess.UpArrow.reference.action.canceled += StopMove;
        m_inputAccess.DownArrow.reference.action.canceled += StopMove;
        m_inputAccess.LeftArrow.reference.action.canceled += StopMove;
        m_inputAccess.RightArrow.reference.action.canceled += StopMove;

    }

    private Vector3 m_forwardDirection;
    private Vector3 m_rightDirection;
    
    void Update()
    {
        
        m_yRotation = m_inputAccess.MousePosition.reference.action.ReadValue<Vector2>().x * Time.fixedDeltaTime *
                      m_speedRotateHorizontal;

        transform.eulerAngles = new Vector3(0, m_yRotation, 0);

        m_forwardDirection = transform.forward;
        m_rightDirection = transform.right;
        
        
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
        m_rigidbody.velocity = direction * m_speedMoving;
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