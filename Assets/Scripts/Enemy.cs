using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Events.UnityEvent m_onStart = null;
    public void StartSet()
    {
        m_onStart?.Invoke();
    }
}
