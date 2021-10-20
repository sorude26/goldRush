using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyShot : MonoBehaviour
{
    [SerializeField] Rigidbody m_rb;
    public Rigidbody ShotRB { get => m_rb; }
}
