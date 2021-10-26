using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField]
    int m_maxLife = 10;
    [SerializeField]
    float m_movePower = 1.2f;
    [SerializeField]
    Rigidbody m_rb = default;
    public int CurrentLife { get; private set; }
    private void Start()
    {
        CurrentLife = m_maxLife;
        if (InputController.Instance)
        {
            InputController.Instance.OnMove += Move;
        }
    }
    public void Move(int dir)
    {
        m_rb.velocity = Vector3.right * dir * m_movePower;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shot")
        {
            CurrentLife--;
            EffectPool.Instance.PlayEffect(EffectType.Hit, other.transform.position);
            GameManager.Instance.Damage();
            other.gameObject?.SetActive(false);
            if (CurrentLife <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
