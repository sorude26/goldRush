using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPool : MonoBehaviour
{
    public static CoinPool Instance { get; private set; }
    [SerializeField]
    int m_allCoinNumber = 500;
    [SerializeField]
    Coin m_coinPrefab = default;
    Coin[] m_allCoins = default;    
    private void Awake()
    {
        Instance = this;
        m_allCoins = new Coin[m_allCoinNumber];
        for (int i = 0; i < m_allCoinNumber; i++)
        {
            var coin = Instantiate(m_coinPrefab);
            coin.transform.SetParent(transform);
            m_allCoins[i] = coin;
            coin.gameObject.SetActive(false);
        }
    }
    public void CallCoin(Vector3 pos)
    {
        foreach (var coin in m_allCoins)
        {
            if (coin.gameObject.activeSelf)
            {
                continue;
            }
            else
            {
                coin.transform.position = pos;
                coin.gameObject.SetActive(true);
                coin.CoinRB.velocity = Vector3.zero;
                coin.transform.rotation = Quaternion.Euler(0, 0, 0);
                return;
            }
        }
    }
    public Coin ShotCoin(Vector3 pos)
    {
        foreach (var coin in m_allCoins)
        {
            if (coin.gameObject.activeSelf)
            {
                continue;
            }
            else
            {
                coin.transform.position = pos;
                coin.gameObject.SetActive(true);
                coin.CoinRB.velocity = Vector3.zero;
                return coin;
            }
        }
        return null;
    }
    public void AddCount()
    {
        GameManager.Instance.UpdateCount();
    }
}
