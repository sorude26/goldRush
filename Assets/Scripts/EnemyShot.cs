using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyShot : MonoBehaviour
{
    [SerializeField]
    Rigidbody m_rb = default;
    public Rigidbody ShotRB { get => m_rb; }
    public void DestroySot()
    {
        Destroy(gameObject);
    }
}
