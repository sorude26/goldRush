using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoinGenerator : MonoBehaviour
{
    public void OnClick()
    {
        CoinPool.Instance.CallCoin(transform.position);
    }
}
