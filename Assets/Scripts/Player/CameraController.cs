using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] private Camera m_camera;
    [SerializeField] private float m_speedRotateHorizontal = 10f;
    [SerializeField] private GameObject m_player;
    private float m_xRotation;

    private InputAccess m_inputAccess;
    private PlayerStats m_playerStats;
    private Vector3 m_mousePos;
    [SerializeField]
    private float m_pitch;
    private void Awake()
    {
        m_inputAccess = GeneralScriptableObject.Instance.InputAccess;
        m_playerStats = GeneralScriptableObject.Instance.PlayerStats;
    }
    void Update()
    {
        
        m_mousePos =
            new Vector3(m_inputAccess.MousePositionX.reference.action.ReadValue<float>(), m_inputAccess.MousePositionY.reference.action.ReadValue<float>() - (m_camera.pixelHeight / 2), m_camera.nearClipPlane);
        
        m_pitch -= m_mousePos.y * m_playerStats.SpeedVerticalRotation * Time.deltaTime;
        m_pitch = Mathf.Clamp(m_pitch, m_playerStats.XRotationClampMin, m_playerStats.XRotationClampMax);
        
        transform.localRotation = Quaternion.Euler(m_pitch, 0, 0);
    }
}
