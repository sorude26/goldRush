using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoinGenerator : MonoBehaviour
{
    [SerializeField]
    float m_interval = 1f;
    float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > m_interval)
        {
            timer = 0;
            OnClick();
        }
    }
    public void OnClick()
    {
        CoinPool.Instance.CallCoin(transform.position);
    }
}
