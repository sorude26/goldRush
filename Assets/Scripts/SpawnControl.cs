using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [SerializeField]
    float[] m_spawnSpeed = default;
    [SerializeField]
    float[] m_spawnTime = default;
    [SerializeField]
    EnemyPool[] m_enemyPools = default;
    [SerializeField]
    Transform[] m_spawnPos = default;
    float[] m_allSpawnSpeed = default;
    float[] m_timers = default;
    bool m_spawn = false;
    int m_count = 0;
    [SerializeField]
    Transform[] m_startSpawnPos = default;

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
        m_timers[0] += m_allSpawnSpeed[0] * Time.deltaTime;
        if (m_timers[0] >= m_spawnTime[0])
        {
            var spawnObject = m_enemyPools[0].GetEnemy(m_spawnPos[m_count].position);
            spawnObject?.StartSet();
            m_count++;
            m_timers[0] = 0;
            if (m_count >= m_spawnPos.Length)
            {
                m_count = 0;
                PositionShuffle();
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
        for (int i = 0; i < m_startSpawnPos.Length; i++)
        {
            var spawnObject = m_enemyPools[0].GetEnemy(m_startSpawnPos[i].position);
            spawnObject?.StartSet();
        }
    }
    void SpeedUp(float speed)
    {
        for (int i = 0; i < m_allSpawnSpeed.Length; i++)
        {
            m_allSpawnSpeed[i] += m_spawnSpeed[i] * speed;
        }
    }
}
