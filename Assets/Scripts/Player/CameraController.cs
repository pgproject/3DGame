using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private InputAccess m_inputAccess;
    private InputAction m_mouseDeltaInput;
    private PlayerStats m_playerStats;

    private float m_mouseSensitivity;
    private float m_smoothing;
    private float m_minYRotation;
    private float m_maxYRotation;
    
    private Vector2 m_mouseDelta;
    private Vector2 m_frameVelocity;
    private Vector2 m_rawFrameVelocity;
    private Vector2 m_velocity;

    [SerializeField] private Transform m_playerTransform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        m_playerStats = GeneralScriptableObject.Instance.PlayerStats;
        m_inputAccess = GeneralScriptableObject.Instance.InputAccess;
        m_mouseDeltaInput = m_inputAccess.MouseDelta.reference.action;
        
        m_mouseSensitivity = m_playerStats.MouseSensitivity;
        m_smoothing = m_playerStats.CameraSmoothing;
        m_minYRotation = m_playerStats.CameraYRotationMin;
        m_maxYRotation = m_playerStats.CameraYRotationMax;
    }

    void Update()
    {
        m_mouseDelta = m_mouseDeltaInput.ReadValue<Vector2>();
        m_rawFrameVelocity = Vector2.Scale(m_mouseDelta, Vector2.one * m_mouseSensitivity);
        
        m_frameVelocity = Vector2.Lerp(m_frameVelocity, m_rawFrameVelocity, 1 / m_smoothing);
        m_velocity += m_frameVelocity;
        m_velocity.y = Mathf.Clamp(m_velocity.y, m_minYRotation, m_maxYRotation);
        
        transform.localRotation = Quaternion.AngleAxis(-m_velocity.y, Vector3.right);
        m_playerTransform.localRotation = Quaternion.AngleAxis(m_velocity.x, Vector3.up);
    }
}
