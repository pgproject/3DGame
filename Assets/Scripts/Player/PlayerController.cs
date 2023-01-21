using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private PlayerCombat m_playerCombat;

    private InputAccess m_inputAccess;
    private PlayerStats m_playerStats;
    private InputAction m_move;

    private float m_movingSpeed;

    private Vector2 m_targetVelocity;


    private void Start()
    {
        m_inputAccess = GeneralScriptableObject.Instance.InputAccess;
        m_playerStats = GeneralScriptableObject.Instance.PlayerStats;

        m_move = m_inputAccess.Move.reference.action;
        m_movingSpeed = m_playerStats.SpeedMoving;
    }

    void Update()
    {
        /*if (m_inputAccess.MeleeAttack.reference.action.triggered)
            m_playerCombat.MeleeAttack();

        if (m_inputAccess.RangedAttack.reference.action.triggered)
            m_playerCombat.RangedAttack();*/
    }

    private void FixedUpdate()
    {
        m_targetVelocity = m_move.ReadValue<Vector2>() * Vector2.one * m_movingSpeed;

        m_rigidbody.velocity =
            transform.rotation * new Vector3(m_targetVelocity.x, m_rigidbody.velocity.y, m_targetVelocity.y);
    }

    private void OnValidate()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_playerCombat = GetComponent<PlayerCombat>();
    }
}