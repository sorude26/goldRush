using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    Text m_shotCount = default;
    public int Count { get; private set; }
    int m_count = 100;
    private void Awake()
    {
        Instance = this;
        Count = m_count;
    }
    public void AddShot()
    {
        if (Count > 1)
        {
            Count -= 2;
            m_shotCount.text = $"All:{Count}G";
        }
    }
    public void UpdateCount()
    {
        Count++;
        m_shotCount.text = $"All:{Count}G";
    }
}
