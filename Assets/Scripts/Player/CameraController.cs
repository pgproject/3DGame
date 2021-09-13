using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera m_camera;

    private float m_pixelHight;
    private InputAccess m_inputAccess;
    private PlayerStats m_playerStats;
    private Vector3 m_mousePos;
    private float m_pitch;
    private float m_verticalRotationSpeed;
    private float m_xRotationClampMin;
    private float m_xRotationClampMax;
    private float m_cameraNearPlane;
    private void Awake()
    {
        m_inputAccess = GeneralScriptableObject.Instance.InputAccess;
        m_playerStats = GeneralScriptableObject.Instance.PlayerStats;
        
        m_verticalRotationSpeed = m_playerStats.SpeedVerticalRotation;
        m_xRotationClampMin = m_playerStats.XRotationClampMin;
        m_xRotationClampMax = m_playerStats.XRotationClampMax;
        m_pixelHight = m_camera.pixelHeight / 2;
        m_cameraNearPlane = m_camera.nearClipPlane;
    }
    void Update()
    {
        
        m_mousePos =
            new Vector3(m_inputAccess.MousePositionX.reference.action.ReadValue<float>(), m_inputAccess.MousePositionY.reference.action.ReadValue<float>() - m_pixelHight, m_cameraNearPlane);
        
        m_pitch -= m_mousePos.y * m_verticalRotationSpeed * Time.deltaTime;
        m_pitch = Mathf.Clamp(m_pitch, m_xRotationClampMin, m_xRotationClampMax);
        
        transform.localRotation = Quaternion.Euler(m_pitch, 0, 0);
    }
}
