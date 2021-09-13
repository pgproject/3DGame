using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera m_camera;

    private float m_pixelHeight;
    private InputAccess m_inputAccess;
    private PlayerStats m_playerStats;
    private Vector3 m_mousePos;
    private float m_pitch;
    private float m_verticalRotationSpeed;
    private float m_xRotationClampMin;
    private float m_xRotationClampMax;
    private InputAction m_mousePositionY;
    private void Awake()
    {
        m_inputAccess = GeneralScriptableObject.Instance.InputAccess;
        m_playerStats = GeneralScriptableObject.Instance.PlayerStats;
        
        m_verticalRotationSpeed = m_playerStats.SpeedVerticalRotation;
        m_xRotationClampMin = m_playerStats.XRotationClampMin;
        m_xRotationClampMax = m_playerStats.XRotationClampMax;
        m_pixelHeight = m_camera.pixelHeight / 2;
        m_mousePositionY = m_inputAccess.MousePositionY.reference.action;
    }
    void Update()
    {
        m_pitch = (m_mousePositionY.ReadValue<float>() - m_pixelHeight) * m_verticalRotationSpeed;
        m_pitch = Mathf.Clamp(-m_pitch, m_xRotationClampMin, m_xRotationClampMax);
        
        transform.rotation = Quaternion.Euler(m_pitch, 0, 0);
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, 0, 0);

    }
}
