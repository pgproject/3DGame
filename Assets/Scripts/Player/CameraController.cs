using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float m_xRotationClampMin, m_xRotationClampMax;
    [SerializeField] private float m_speedV = 2f;

    private float m_xRotation;

    private InputAccess m_inputAccess;
    
    private void Awake()
    {
        m_inputAccess = GeneralScriptableObject.Instance.InputAccess;
    }
    void Update()
    {
        m_xRotation = Mathf.Clamp(m_inputAccess.MousePosition.reference.action.ReadValue<Vector2>().y * Time.fixedDeltaTime *
                                  m_speedV, m_xRotationClampMax, m_xRotationClampMin);

        
        if (m_xRotation < 1)
            m_xRotation *= 2; // there should be proportion
        
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        transform.localRotation = Quaternion.Euler(-m_xRotation, 0, 0);
    }
}
