using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{
    [SerializeField]
    float m_rotateSpeed = 1.0f;
    [SerializeField]
    Transform m_target;
    private void Update()
    {
        if (m_target != null)
        {
            Vector3 lockOnPos = m_target.position;
            Vector3 targetDir = lockOnPos - transform.position;
            targetDir.y = 0.0f;
            Quaternion p = Quaternion.Euler(0, 0, 0);
            Quaternion endRot = Quaternion.LookRotation(targetDir) * p;
            transform.rotation = Quaternion.Lerp(transform.rotation, endRot, Time.deltaTime * m_rotateSpeed);
        }
    }
}
