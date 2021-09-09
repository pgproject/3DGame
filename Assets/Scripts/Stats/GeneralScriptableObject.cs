using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "GeneralAccess", menuName = "General/Input", order = 1)]
public sealed class GeneralScriptableObject : ScriptableObject
{
    private static GeneralScriptableObject m_instance;
    public static GeneralScriptableObject Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = Resources.Load<GeneralScriptableObject>("GeneralAccess");
            
            return m_instance;
        }
    }

    private GeneralScriptableObject()
    {
        
    }
    
    [SerializeField] private InputAccess m_inputAccess;
    public InputAccess InputAccess => m_inputAccess;

    [SerializeField] private PlayerStats m_playerStats;
    public PlayerStats PlayerStats => m_playerStats;

    [SerializeField] private EnemyStats m_enemyStats;
    public EnemyStats EnemyStats => m_enemyStats;

}
