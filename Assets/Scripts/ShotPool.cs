using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPool : MonoBehaviour
{
    public static ShotPool Instance { get; private set; }
    [SerializeField]
    int m_maxShotCount = 20;
    [SerializeField]
    EnemyShot m_shotPrefab = default;
    EnemyShot[] m_allShot = default;
    private void Awake()
    {
        Instance = this;
        m_allShot = new EnemyShot[m_maxShotCount];
        for (int i = 0; i < m_maxShotCount; i++)
        {
            var shot = Instantiate(m_shotPrefab);
            shot.transform.SetParent(transform);
            m_allShot[i] = shot;
            shot.gameObject.SetActive(false);
        }
    }
    public void DestroyAll()
    {
        for (int i = 0; i < m_allShot.Length; i++)
        {
            m_allShot[i].DestroySot();
            m_allShot[i] = null;
        }
    }
    public void CallShot(Vector3 pos)
    {
        foreach (var shot in m_allShot)
        {
            if (shot.gameObject.activeSelf)
            {
                continue;
            }
            else
            {
                shot.transform.position = pos;
                shot.gameObject.SetActive(true);
                shot.transform.rotation = Quaternion.Euler(0, 0, 0);
                return;
            }
        }
    }
    public EnemyShot GetShot(Vector3 pos)
    {
        foreach (var shot in m_allShot)
        {
            if (shot.gameObject.activeSelf)
            {
                continue;
            }
            else
            {
                shot.transform.position = pos;
                shot.gameObject.SetActive(true);
                return shot;
            }
        }
        return null;
    }
}
