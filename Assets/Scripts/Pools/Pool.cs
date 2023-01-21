using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private int m_amountOfObjects;
    [SerializeField] private Vector3 m_spawnPosition;
    [SerializeField] private GameObject m_object;
    [SerializeField] private Transform m_parentTransform;
    private Queue<GameObject> m_objects = new Queue<GameObject>();

    public void Awake()
    {
        for (int i = 0; i < m_amountOfObjects; i++)
        {
            GameObject objectToSpawn = Instantiate(m_object, m_spawnPosition, Quaternion.Euler(0, 0, 0), m_parentTransform.transform);
            m_objects.Enqueue(objectToSpawn);
        }
    }

    public void GetObjectFromPool()
    {
        for (int i = 0; i < m_objects.Count; i++)
        {
            if (!m_objects.Dequeue())
            {
                m_objects.Dequeue().SetActive(true);
                return;
            }
        }
        GameObject objectToSpawn = Instantiate(m_object, m_spawnPosition, Quaternion.Euler(0, 0, 0), this.transform);
        m_objects.Enqueue(objectToSpawn);
    }

    public void PutObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = m_spawnPosition;
        obj.GetComponent<Enemy>().ResetHp();
    }
}
