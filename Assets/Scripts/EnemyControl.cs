using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    float m_attackInterval = 3f;
    float m_attackTimer = 0;
    [SerializeField]
    UnityEngine.Events.UnityEvent m_onAttack = null;
    [SerializeField]
    float m_power = 5f;
    [SerializeField]
    EnemyShot m_shot = default;
    [SerializeField]
    Transform m_muzzle = default;
    void Update()
    {
        m_attackTimer += Time.deltaTime;
        if (m_attackTimer >= m_attackInterval)
        {
            m_attackTimer = 0;
            m_onAttack?.Invoke();
        }
    }
    public void Attack()
    {
        var shot = Instantiate(m_shot);
        shot.transform.position = m_muzzle.position;
        shot.ShotRB.AddForce((transform.forward + Vector3.up * 0.5f)*m_power,ForceMode.Impulse);
    }
}
