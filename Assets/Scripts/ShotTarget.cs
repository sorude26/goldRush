using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTarget : MonoBehaviour
{
    [SerializeField]
    GameObject m_body = default;
    [SerializeField]
    Transform m_hitPos = default;
    [SerializeField]
    int m_hp = 10;
    [SerializeField]
    float m_coolTime = 0.3f;
    [SerializeField]
    GameObject m_hitEffect = default;
    [SerializeField]
    GameObject m_deadEffect = default;
    bool m_hit;
    [SerializeField]
    UnityEngine.Events.UnityEvent m_onDead = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin" && !m_hit)
        {
            m_hit = true;
            m_hp--;
            if (m_hp <= 0)
            {
                m_onDead?.Invoke();
                if (m_deadEffect)
                {
                    Instantiate(m_deadEffect).transform.position = transform.position;
                }
                if (m_body)
                {
                    Destroy(m_body);
                }
            }
            else
            {
                StartCoroutine(CoolTime());
            }
        }
    }
    IEnumerator CoolTime()
    {
        if (m_hitEffect)
        {
            if (m_hitPos)
            {
                Instantiate(m_hitEffect).transform.position = m_hitPos.position;
            }
            else
            {
                Instantiate(m_hitEffect).transform.position = transform.position;
            }
        }
        yield return new WaitForSeconds(m_coolTime);
        m_hit = false;
    }
}
