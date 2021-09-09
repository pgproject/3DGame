using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float m_xRotationClampMin, m_xRotationClampMax;
    [SerializeField] private float m_speedV = 2f;
    [SerializeField] private Camera m_camera;
    [SerializeField] private float m_speedRotateHorizontal = 10f;
    [SerializeField] private GameObject m_player;
    private float m_xRotation;

    private InputAccess m_inputAccess;
    private Vector3 m_mousePos;

    private void Awake()
    {
        m_inputAccess = GeneralScriptableObject.Instance.InputAccess;
    }
    void Update()
    {
        
        m_mousePos =
            new Vector3(m_inputAccess.MousePosition.reference.action.ReadValue<Vector2>().x, 
                m_inputAccess.MousePosition.reference.action.ReadValue<Vector2>().y, m_camera.nearClipPlane);
        m_mousePos = m_camera.ScreenToWorldPoint(m_mousePos);
        Debug.Log(m_mousePos);

        m_xRotation = -m_mousePos.y * 20;
        transform.localEulerAngles = new Vector3(Mathf.Clamp(m_xRotation,-90, 50), 0, 0);
        //transform.Rotate(m_xRotation, 0 ,0);
        m_player.transform.eulerAngles= new Vector3(0, m_mousePos.x * m_speedRotateHorizontal * Time.deltaTime, 0);
        //transform.Rotate(m_xRotation * Time.deltaTime * m_speedRotateHorizontal, m_yRotation * Time.deltaTime * m_speedRotateHorizontal, 0);
    }
}
