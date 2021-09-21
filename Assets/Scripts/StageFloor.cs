using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StageFloor : MonoBehaviour
{
    [SerializeField]
    Vector3 m_targetPos = Vector3.forward;
    [SerializeField]
    float m_moveSpeed = 1f;
    [SerializeField]
    float m_waitTime = 2f;
    Vector3 m_startPos;
    Rigidbody m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.isKinematic = true;
        m_rb.useGravity = false;
        m_startPos = gameObject.transform.position;
    }
    
    private void LateUpdate()
    {
        var offs = m_targetPos * Mathf.Sin(Time.time * m_waitTime) * m_moveSpeed;
        m_rb.MovePosition(m_startPos + offs);
    }
}
