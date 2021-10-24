using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField]
    Enemy[] m_dragons = default;
    Vector3[] m_startPos = default;
    int m_current = 0;
    void Start()
    {
        m_startPos = new Vector3[m_dragons.Length];
        for (int i = 0; i < m_dragons.Length; i++)
        {
            m_startPos[i] = m_dragons[i].transform.position;
        }
        foreach (var dragon in m_dragons)
        {
            dragon.gameObject.SetActive(false);
        }
    }

    public void AddDragon()
    {
        int activeCount = 0;
        foreach (var dragon in m_dragons)
        {
            if (dragon.gameObject.activeSelf)
            {
                activeCount++;
            }
        }
        if (activeCount >= m_dragons.Length)
        {
            return;
        }
        m_current++;
        if (m_current >= m_dragons.Length)
        {
            m_current = 0;
        }
        if (!m_dragons[m_current].gameObject.activeSelf)
        {
            m_dragons[m_current].transform.position = m_startPos[m_current];
            m_dragons[m_current].gameObject.SetActive(true);
            m_dragons[m_current].StartSet();
        }
        else
        {
            AddDragon();
        }
    }
}
