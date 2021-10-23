using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    int m_maxEnemyCount = 20;
    [SerializeField]
    Enemy m_enemyPrefab = default;
    Enemy[] m_allEnemys = default;
    private void Awake()
    {
        m_allEnemys = new Enemy[m_maxEnemyCount];
        for (int i = 0; i < m_maxEnemyCount; i++)
        {
            var enemy = Instantiate(m_enemyPrefab);
            enemy.transform.SetParent(transform);
            m_allEnemys[i] = enemy;
            enemy.gameObject.SetActive(false);
        }
    }
    public void CallEnemy(Vector3 pos)
    {
        foreach (var enemy in m_allEnemys)
        {
            if (enemy.gameObject.activeSelf)
            {
                continue;
            }
            else
            {
                enemy.transform.position = pos;
                enemy.gameObject.SetActive(true);
                enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                return;
            }
        }
    }
    public Enemy GetEnemy(Vector3 pos)
    {
        foreach (var enemy in m_allEnemys)
        {
            if (enemy.gameObject.activeSelf)
            {
                continue;
            }
            else
            {
                enemy.transform.position = pos;
                enemy.gameObject.SetActive(true);
                return enemy;
            }
        }
        return null;
    }
}
