using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField]
    Transform[] m_coinPos = default;
    void Start()
    {
        for (int i = 0; i < m_coinPos.Length; i++)
        {
            CoinPool.Instance.CallCoin(m_coinPos[i].position);
        }
        for (int i = 0; i < m_coinPos.Length; i++)
        {
            CoinPool.Instance.CallCoin(m_coinPos[i].position + new Vector3(0,0.1f,0));
        }
    }
}
