using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveStraight : MonoBehaviour
{
    [SerializeField]
    float m_speed = 2f;
    Rigidbody m_rb = default;
    Vector3 m_dir = default;
    Vector3 m_start = default;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
        m_start = transform.position;
        m_dir = -m_start.normalized;
        m_dir.y = 0;
    }
    
    private void LateUpdate()
    {
        var offs = m_dir * Time.time * m_speed;
        m_rb.MovePosition(m_start + offs);
    }
}
