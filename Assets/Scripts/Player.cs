using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int m_maxLife = 10;
    public int CurrentLife { get; private set; }
    private void Start()
    {
        CurrentLife = m_maxLife;
    }
}
