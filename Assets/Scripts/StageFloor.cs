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
    Rigidbody m_rB;
    void Start()
    {
        m_rB = GetComponent<Rigidbody>();
        m_rB.isKinematic = true;
        m_rB.useGravity = false;
        m_startPos = gameObject.transform.position;
        //StartCoroutine(AutoMove());
    }
    private void Update()
    {
        var offs = new Vector3(0, 0, Mathf.Sin(Time.time) * m_moveSpeed);
        m_rB.MovePosition(m_startPos + offs);
    }
    IEnumerator AutoMove()
    {
        while (true)
        {
            yield return Move(m_targetPos, m_startPos);
            yield return Wait();
            yield return Move(m_startPos, m_targetPos);
            yield return Wait();
        }
    }
    IEnumerator Move(Vector3 target, Vector3 start)
    {
        Vector3 dir = (target - start).normalized;
        while ((target - gameObject.transform.position).sqrMagnitude > 0.2f)
        {
            //m_rB.velocity = dir * m_moveSpeed;
            m_rB.MovePosition(target);
            yield return null;
        }
    }
    IEnumerator Wait()
    {
        m_rB.velocity = Vector3.zero;
        yield return new WaitForSeconds(m_waitTime);
    }
}
