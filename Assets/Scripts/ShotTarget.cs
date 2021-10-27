using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTarget : MonoBehaviour
{
    [SerializeField]
    int m_score = 100;
    [SerializeField]
    Transform m_hitPos = default;
    [SerializeField]
    int m_hp = 10;
    int m_currentHp = default;
    [SerializeField]
    float m_coolTime = 0.3f;
    float m_coolTimer = default;
    [SerializeField]
    EffectType m_hitEffect = default;
    [SerializeField]
    EffectType m_deadEffect = default;
    bool m_hit;
    [SerializeField]
    UnityEngine.Events.UnityEvent m_onDead = null;
    private void Start()
    {
        StartSet();
    }
    public void StartSet()
    {
        m_currentHp = m_hp;
        m_hit = false;
        m_coolTimer = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin" && !m_hit)
        {
            m_hit = true;
            m_currentHp--;
            if (m_currentHp <= 0)
            {
                m_onDead?.Invoke();
                EffectPool.Instance.PlayEffect(m_deadEffect, transform.position);
                if (m_score > 0)
                {
                    var score = TextPool.Instance.GetScore(m_hitPos.position);
                    score.ViewScore(m_score);
                }
                gameObject.SetActive(false);
            }
            else
            {
                if (m_hitPos)
                {
                    EffectPool.Instance.PlayEffect(m_hitEffect, m_hitPos.position);
                }
                else
                {
                    EffectPool.Instance.PlayEffect(m_hitEffect, transform.position);
                }
            }
        }
    }
    private void Update()
    {
        if (!m_hit)
        {
            return;
        }
        if (m_coolTimer < m_coolTime)
        {
            m_coolTimer += Time.deltaTime;
            if (m_coolTimer >= m_coolTime)
            {
                m_coolTimer = 0;
                m_hit = false;
            }
        }
    }
}
