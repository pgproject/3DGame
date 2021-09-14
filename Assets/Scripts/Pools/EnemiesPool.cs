using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class EnemiesPool : MonoBehaviour
{
    [SerializeField] private int m_amountOfEnemies;
    [SerializeField] private Vector3 m_spawnPosition;
    [SerializeField] private GameObject m_enemy; 
    private List<GameObject> m_enemies = new List<GameObject>();

    public void Awake()
    {
        for (int i = 0; i < m_amountOfEnemies; i++)
        {
            GameObject enemy = Instantiate(m_enemy, m_spawnPosition, Quaternion.Euler(0, 0, 0), this.transform);
            m_enemies.Add(enemy);
        }
    }

    public void GetObjectFromPool()
    {
        for (int i = 0; i < m_enemies.Count; i++)
        {
            if (!m_enemies[i].activeSelf)
            {
                m_enemies[i].SetActive(true);
                return;
            }
        }
        GameObject enemy = Instantiate(m_enemy, m_spawnPosition, Quaternion.Euler(0, 0, 0), this.transform);
        m_enemies.Add(enemy);
    }

    public void PutObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = m_spawnPosition;
        obj.GetComponent<Enemy>().ResetHp();
    }
}
