using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTarget : MonoBehaviour
{
    [SerializeField]
    GameObject m_body = default;
    [SerializeField]
    int m_hp = 10;
    [SerializeField]
    float m_coolTime = 0.3f;
    bool m_hit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin" && !m_hit)
        {
            m_hit = true;
            m_hp--;
            if (m_hp <= 0)
            {
                Destroy(m_body);
            }
            else
            {
                StartCoroutine(CoolTime());
            }
        }
    }
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(m_coolTime);
        m_hit = false;
    }
}
