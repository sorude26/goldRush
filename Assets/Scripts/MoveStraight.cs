using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    [SerializeField]
    float m_speed = 2f;
    Vector3 m_dir = default;
    Vector3 m_start = Vector3.zero;
    float m_timer = 0;
    public void StartSet()
    {
        m_timer = 0;
        m_start = this.transform.position;
        m_dir = -m_start.normalized;
        m_dir.y = 0;
        transform.forward = m_dir;
    }
    private void Update()
    {
        m_timer += Time.deltaTime;
        transform.position = m_start + m_dir * m_timer * m_speed;
    }
}
