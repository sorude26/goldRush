using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveStraight : MonoBehaviour
{
    [SerializeField]
    float m_speed = 2f;
    [SerializeField]
    Rigidbody m_rb = default;
    Vector3 m_dir = default;
    Vector3 m_start = Vector3.zero;
    bool m_move = false;
    float m_timer = 0;
    public void StartSet()
    {
        m_start = this.transform.position;
        m_dir = -m_start.normalized;
        m_dir.y = 0;
        transform.forward = m_dir;
        m_move = true;
    }
    private void LateUpdate()
    {
        if (!m_move)
        {
            return;
        }
        m_timer += Time.deltaTime;
        var offs = m_dir * m_timer * m_speed;
        m_rb.MovePosition(m_start + offs);
    }
}
