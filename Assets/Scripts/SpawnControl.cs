using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [SerializeField]
    float[] m_spawnSpeed;
    [SerializeField]
    float[] m_spawnTime;
    [SerializeField]
    GameObject[] m_spawnObjects;
    [SerializeField]
    Transform[] m_spawnPos;
    float[] m_allSpawnSpeed;
    float[] m_timers;
    bool m_spawn = false;
    int m_count = 0;

    void Start()
    {
        StartSpawn();
        m_timers = new float[m_spawnSpeed.Length];
        m_allSpawnSpeed = new float[m_spawnSpeed.Length];
        for (int i = 0; i < m_allSpawnSpeed.Length; i++)
        {
            m_allSpawnSpeed[i] = 1f;
        }
    }

    void Update()
    {
        if (!m_spawn) return;
        for (int i = 0; i < m_timers.Length; i++)
        {
            m_timers[i] += m_allSpawnSpeed[i] * Time.deltaTime;
            if (m_timers[i] >= m_spawnTime[i])
            {
                var spawnObject = Instantiate(m_spawnObjects[i]);
                spawnObject.transform.position = m_spawnPos[m_count].position;
                m_count++;
                m_timers[i] = 0;
                if (m_count >= m_spawnPos.Length)
                {
                    m_count = 0;
                    PositionShuffle();
                }
            }
        }
    }
    void PositionShuffle()
    {
        for (int i = 0; i < m_spawnPos.Length; i++)
        {
            int r = Random.Range(0, m_spawnPos.Length);
            Transform p = m_spawnPos[i];
            m_spawnPos[i] = m_spawnPos[r];
            m_spawnPos[r] = p;
        }
    }
    void StopSpawn()
    {
        m_spawn = false;
        for (int i = 0; i < m_timers.Length; i++)
        {
            m_timers[i] = 0;
        }
        for (int i = 0; i < m_allSpawnSpeed.Length; i++)
        {
            m_allSpawnSpeed[i] = 1f;
        }
    }
    void StartSpawn()
    {
        m_spawn = true;
        m_count = 0;
        PositionShuffle();
    }
    void SpeedUp(float speed)
    {
        for (int i = 0; i < m_allSpawnSpeed.Length; i++)
        {
            m_allSpawnSpeed[i] += m_spawnSpeed[i] * speed;
        }
    }
}
